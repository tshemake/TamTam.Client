using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TamTam.Bot.Connector;
using TamTam.Bot.Schema;

namespace TamTam.Bot.Sender
{
    public class SenderApi
    {
        public static readonly JsonSerializerSettings SerializationSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
        };
        public static readonly JsonSerializerSettings DeserializationSettings = new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
        };

        public static async Task<ApiResponse<PhotoTokenList>> UploadPhotoAsync(IConnectorClient connectorClient, string requestUri, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            return await UploadAsync<PhotoTokenList>(connectorClient, requestUri, assetName, stream, cancellationToken);
        }

        public static async Task<ApiResponse<UploadedInfo>> UploadVideoAsync(IConnectorClient connectorClient, string requestUri, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            return await UploadAsync<UploadedInfo>(connectorClient, requestUri, assetName, stream, cancellationToken);
        }

        public static async Task<ApiResponse<UploadedInfo>> UploadAudioAsync(IConnectorClient connectorClient, string requestUri, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            return await UploadAsync<UploadedInfo>(connectorClient, requestUri, assetName, stream, cancellationToken);
        }
        public static async Task<ApiResponse<UploadedFileInfo>> UploadFileAsync(IConnectorClient connectorClient, string requestUri, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            return await UploadAsync<UploadedFileInfo>(connectorClient, requestUri, assetName, stream, cancellationToken);
        }

        public static async Task<ApiResponse<T>> PostAsync<T>(IConnectorClient connectorClient, string requestUri, object payload, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Post,
                Uri = requestUri,
                Payload = payload,
            };
            return await SendAsync(connectorClient, request);
        }

        public static async Task<ApiResponse<T>> PutAsync<T>(IConnectorClient connectorClient, string requestUri, object payload, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Put,
                Uri = requestUri,
                Payload = payload,
            };
            return await SendAsync(connectorClient, request);
        }

        public static async Task<ApiResponse<T>> PatchAsync<T>(IConnectorClient connectorClient, string requestUri, object payload, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Patch,
                Uri = requestUri,
                Payload = payload,
            };
            return await SendAsync(connectorClient, request);
        }

        public static async Task<ApiResponse<T>> GetAsync<T>(IConnectorClient connectorClient, string requestUri, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Get,
                Uri = requestUri,
            };
            return await SendAsync(connectorClient, request);
        }

        public static async Task<ApiResponse<T>> DeleteAsync<T>(IConnectorClient connectorClient, string requestUri, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Delete,
                Uri = requestUri,
            };
            return await SendAsync(connectorClient, request);
        }

        public static async Task<ApiResponse<T>> UploadAsync<T>(IConnectorClient connectorClient, string requestUri, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            using (var content = new MultipartFormDataContent())
            {
                var streamContent = new StreamContent(stream);
                var byteArrayContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                content.Add(byteArrayContent, "data", assetName);
                using (var httpResponse = await connectorClient.HttpClient.PostAsync(requestUri, content))
                {
                    return await OnResponse<T>(httpResponse);
                }
            }
        }

        public static async Task<ApiResponse<T>> SendAsync<T>(IConnectorClient connectorClient, IRequest<T> request, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var req = new HttpRequestMessage(request.HttpMethod, request.Uri))
                {
                    if (request.Payload != null)
                    {
                        string requestCmd = JsonConvert.SerializeObject(request.Payload, SerializationSettings);
                        req.Content = new StringContent(requestCmd, Encoding.UTF8, ContentTypes.ApplicationJson);
                    }
                    using (var httpResponse = await connectorClient.HttpClient.SendAsync(req, cancellationToken))
                    {
                        if (IsJsonContentType(httpResponse))
                        {
                            return await OnResponse<T>(httpResponse);
                        }
                        return new ApiResponse<T>(false, default, new ResultInfo(httpResponse.StatusCode, $"Service sent unknown content-type from url {request.Uri}."));
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>(false, default, new ResultInfo(ex));
            }
        }

        private static async Task<ApiResponse<T>> OnResponse<T>(HttpResponseMessage httpResponse)
        {
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                var value = await ReadContentAsJsonAsync<T>(httpResponse);
                return new ApiResponse<T>(true, value, new ResultInfo(httpResponse.StatusCode));
            }
            else
            {
                var value = await ReadContentAsJsonAsync<Error>(httpResponse);
                return new ApiResponse<T>(false, default, new ResultInfo(httpResponse.StatusCode, value.Code, value.Message));
            }
        }

        private static async Task<TResult> ReadContentAsJsonAsync<TResult>(HttpResponseMessage message)
        {
            var content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content, DeserializationSettings);
        }

        private static bool IsJsonContentType(HttpResponseMessage httpResponse)
        {
            return httpResponse.Content.Headers.ContentType.MediaType == ContentTypes.ApplicationJson;
        }
    }
}
