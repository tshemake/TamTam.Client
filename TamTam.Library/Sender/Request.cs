using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TamTam.Bot.Sender
{
    public class Request<TResponse> : IRequest<TResponse>
    {
        public HttpMethod HttpMethod { get ; set; }
        public object Payload { get; set; }
        public string Uri { get; set; }
    }
}
