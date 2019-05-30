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
using TamTam.Bot.Exceptions;
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

        public static async Task<ApiResponse<PhotoTokenList>> UploadPhotoAsync(IConnectorClient connectorClient, Uri requestUri, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            return await UploadAsync<PhotoTokenList>(connectorClient, requestUri, assetName, stream, cancellationToken);
        }

        public static async Task<ApiResponse<UploadedInfo>> UploadVideoAsync(IConnectorClient connectorClient, Uri requestUri, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            return await UploadAsync<UploadedInfo>(connectorClient, requestUri, assetName, stream, cancellationToken);
        }

        public static async Task<ApiResponse<UploadedInfo>> UploadAudioAsync(IConnectorClient connectorClient, Uri requestUri, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            return await UploadAsync<UploadedInfo>(connectorClient, requestUri, assetName, stream, cancellationToken);
        }
        public static async Task<ApiResponse<UploadedFileInfo>> UploadFileAsync(IConnectorClient connectorClient, Uri requestUri, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            return await UploadAsync<UploadedFileInfo>(connectorClient, requestUri, assetName, stream, cancellationToken);
        }

        public static async Task<ApiResponse<T>> PostAsync<T>(IConnectorClient connectorClient, Uri requestUri, object payload, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Post,
                RequestUri = requestUri,
                Payload = payload,
            };
            return await SendAsync(connectorClient, request, cancellationToken);
        }

        public static async Task<ApiResponse<T>> PutAsync<T>(IConnectorClient connectorClient, Uri requestUri, object payload, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Put,
                RequestUri = requestUri,
                Payload = payload,
            };
            return await SendAsync(connectorClient, request, cancellationToken);
        }

        public static async Task<ApiResponse<T>> PatchAsync<T>(IConnectorClient connectorClient, Uri requestUri, object payload, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Patch,
                RequestUri = requestUri,
                Payload = payload,
            };
            return await SendAsync(connectorClient, request, cancellationToken);
        }

        public static async Task<ApiResponse<T>> GetAsync<T>(IConnectorClient connectorClient, Uri requestUri, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Get,
                RequestUri = requestUri,
            };
            return await SendAsync(connectorClient, request, cancellationToken);
        }

        public static async Task<ApiResponse<T>> DeleteAsync<T>(IConnectorClient connectorClient, Uri requestUri, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Delete,
                RequestUri = requestUri,
            };
            return await SendAsync(connectorClient, request, cancellationToken);
        }

        public static async Task<ApiResponse<T>> UploadAsync<T>(IConnectorClient connectorClient, Uri requestUri, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            using (var content = new MultipartFormDataContent())
            {
                var streamContent = new StreamContent(stream);
                var byteArrayContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                content.Add(byteArrayContent, "data", assetName);
                using (var req = new HttpRequestMessage(HttpMethod.Post, requestUri))
                {
                    if (content != null)
                    {
                        req.Content = content;
                    }
                    return await SendAsync<T>(connectorClient, req, cancellationToken);
                }
            }
        }

        public static async Task<ApiResponse<T>> SendAsync<T>(IConnectorClient connectorClient, IRequest<T> request, CancellationToken cancellationToken = default)
        {
            using (var req = new HttpRequestMessage(request.HttpMethod, request.RequestUri))
            {
                if (request.Payload != null)
                {
                    string requestCmd = JsonConvert.SerializeObject(request.Payload, SerializationSettings);
                    req.Content = new StringContent(requestCmd, Encoding.UTF8, ContentTypes.ApplicationJson);
                }
                return await SendAsync<T>(connectorClient, req, cancellationToken);
            }
        }

        public static async Task<ApiResponse<T>> SendAsync<T>(IConnectorClient connectorClient, HttpRequestMessage request, CancellationToken cancellationToken = default)
        {
            using (var httpResponse = await SendAsyncCancellationSafeAsync(connectorClient.HttpClient, request, cancellationToken))
            {
                if (IsJsonContentType(httpResponse))
                {
                    return await OnResponse<T>(httpResponse);
                }
                return new ApiResponse<T>(false, default, new ResultInfo(new HttpStatus((int)httpResponse.StatusCode), new ApiRequestException($"Service sent unknown content-type from url {request.RequestUri}.", (int)httpResponse.StatusCode)));
            }
        }

        public static async Task<HttpResponseMessage> SendAsyncCancellationSafeAsync(HttpClient instance, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                return await instance.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (TaskCanceledException ex)
            {
                cancellationToken.ThrowIfCancellationRequested();

                throw new ApiRequestException("Failed to perform HTTP request", (int)HttpStatusCode.RequestTimeout, ex);
            }
        }

        private static async Task<ApiResponse<T>> OnResponse<T>(HttpResponseMessage httpResponse)
        {
            string responseContent = default;
            try
            {
                var actualResponseStatusCode = httpResponse.StatusCode;
                responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                switch (actualResponseStatusCode)
                {
                    case HttpStatusCode.OK when !string.IsNullOrWhiteSpace(responseContent):
                        {
                            var value = DeserializeObject<T>(responseContent);
                            return new ApiResponse<T>(true, value, new ResultInfo(new HttpStatus((int)httpResponse.StatusCode, responseContent)));
                        }
                    case HttpStatusCode.BadRequest when !string.IsNullOrWhiteSpace(responseContent):
                    case HttpStatusCode.Unauthorized when !string.IsNullOrWhiteSpace(responseContent):
                    case HttpStatusCode.NotFound when !string.IsNullOrWhiteSpace(responseContent):
                    case HttpStatusCode.MethodNotAllowed when !string.IsNullOrWhiteSpace(responseContent):
                    case HttpStatusCode.TooManyRequests when !string.IsNullOrWhiteSpace(responseContent):
                    case HttpStatusCode.ServiceUnavailable when !string.IsNullOrWhiteSpace(responseContent):
                        {
                            var error = DeserializeObject<Error>(responseContent);
                            return new ApiResponse<T>(false, default, new ResultInfo(new HttpStatus((int)httpResponse.StatusCode, responseContent), new TamTamBotException(error)));
                        }
                    default:
                        {
                            httpResponse.EnsureSuccessStatusCode();
                            return new ApiResponse<T>(true, default, new ResultInfo(new HttpStatus((int)httpResponse.StatusCode, responseContent)));
                        }
                }
            }
            catch (JsonException ex)
            {
                return new ApiResponse<T>(false, default, new ResultInfo(new HttpStatus((int)httpResponse.StatusCode, responseContent), ex));
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<T>(false, default, new ResultInfo(new HttpStatus((int)httpResponse.StatusCode, responseContent), ex));
            }
            catch
            {
                return new ApiResponse<T>(false, default, new ResultInfo(new HttpStatus((int)httpResponse.StatusCode, responseContent),
                    new ApiRequestException($"Operation returned an invalid status code '{(int)httpResponse.StatusCode}'", (int)httpResponse.StatusCode)));
            }
        }

        private static async Task<TResult> ReadContentAsJsonAsync<TResult>(HttpResponseMessage message)
        {
            var content = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            return DeserializeObject<TResult>(content);
        }

        private static TResult DeserializeObject<TResult>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<TResult>(json, DeserializationSettings);
            }
            catch (JsonException ex)
            {
                throw new ApiSerializationException("Unable to deserialize the response.", json, ex);
            }
        }

        private static bool IsJsonContentType(HttpResponseMessage httpResponse)
        {
            return httpResponse.Content.Headers.ContentType.MediaType == ContentTypes.ApplicationJson;
        }
    }
}
