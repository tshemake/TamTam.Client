using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TamTam.Bot.Connector
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient()
        {
            return new HttpClient();
        }
    }
}
