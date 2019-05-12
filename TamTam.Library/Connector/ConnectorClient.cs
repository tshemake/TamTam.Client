using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace TamTam.Bot.Connector
{
    public class ConnectorClient : IConnectorClient
    {
        public Uri BaseUri { get; private set; }
        public HttpClient HttpClient { get; private set; }

        public ConnectorClient(IHttpClientFactory httpClientFactory)
        {
            if (httpClientFactory == null)
            {
                throw new ArgumentNullException(nameof(httpClientFactory));
            }
            HttpClient = httpClientFactory.CreateClient();
            Initialize();
        }

        private void Initialize()
        {
            BaseUri = new Uri("https://botapi.tamtam.chat");
            HttpClient.BaseAddress = BaseUri;
            AddDefaultRequestHeaders();
        }

        private void AddDefaultRequestHeaders()
        {
            var userAgent = $"({GetASPNetVersion()}; {GetOsVersion()}; {GetArchitecture()})";
            SetUserAgent(userAgent);

            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentTypes.ApplicationJson));
            HttpClient.DefaultRequestHeaders.ExpectContinue = false;
        }

        private bool SetUserAgent(string userAgent)
        {
            if (ProductInfoHeaderValue.TryParse(userAgent, out var additionalProductInfo))
            {
                if (!HttpClient.DefaultRequestHeaders.UserAgent.Contains(additionalProductInfo))
                {
                    HttpClient.DefaultRequestHeaders.UserAgent.Add(additionalProductInfo);
                    return true;
                }
            }
            return false;
        }

        public static string GetOsVersion()
        {
            return RuntimeInformation.OSDescription;
        }

        public static string GetArchitecture()
        {
            return RuntimeInformation.OSArchitecture.ToString();
        }

        public static string GetASPNetVersion()
        {
            return Assembly
                    .GetEntryAssembly()?
                    .GetCustomAttribute<TargetFrameworkAttribute>()?
                    .FrameworkName;
        }
    }
}
