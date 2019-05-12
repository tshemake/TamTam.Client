using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

        public static async Task<ApiResponse<T>> PostAsync<T>(IConnectorClient connectorClient, string uri, object payload, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Post,
                Uri = uri,
                Payload = payload,
            };
            return await SendAsync(connectorClient, request);
        }

        public static async Task<ApiResponse<T>> PutAsync<T>(IConnectorClient connectorClient, string uri, object payload, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Put,
                Uri = uri,
                Payload = payload,
            };
            return await SendAsync(connectorClient, request);
        }

        public static async Task<ApiResponse<T>> PatchAsync<T>(IConnectorClient connectorClient, string uri, object payload, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Patch,
                Uri = uri,
                Payload = payload,
            };
            return await SendAsync(connectorClient, request);
        }

        public static async Task<ApiResponse<T>> GetAsync<T>(IConnectorClient connectorClient, string uri, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Get,
                Uri = uri,
            };
            return await SendAsync(connectorClient, request);
        }

        public static async Task<ApiResponse<T>> DeleteAsync<T>(IConnectorClient connectorClient, string uri, CancellationToken cancellationToken = default)
        {
            var request = new Request<T>
            {
                HttpMethod = HttpMethod.Delete,
                Uri = uri,
            };
            return await SendAsync(connectorClient, request);
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
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            if (IsJsonContentType(httpResponse))
                            {
                                var value = await ReadContentAsJsonAsync<T>(httpResponse);
                                return new ApiResponse<T>(true, value, new ResultInfo(httpResponse.StatusCode));
                            }
                            return new ApiResponse<T>(false, default, new ResultInfo(httpResponse.StatusCode, $"Service sent unknown content-type from url {request.Uri}"));
                        }
                        else
                        {
                            if (IsJsonContentType(httpResponse))
                            {
                                var value = await ReadContentAsJsonAsync<Error>(httpResponse);
                                return new ApiResponse<T>(false, default, new ResultInfo(httpResponse.StatusCode, value.Code, value.Message));
                            }
                            return new ApiResponse<T>(false, default, new ResultInfo(httpResponse.StatusCode));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>(false, default, new ResultInfo(ex));
            }
        }

        private static async Task<TResult> ReadContentAsJsonAsync<TResult>(HttpResponseMessage message)
        {
            var content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content, DeserializationSettings);
        }

        private static bool IsJsonContentType(HttpResponseMessage httpResponse)
        {
            return httpResponse.Content.Headers.ContentType.MediaType == "application/json";
        }
    }
}
