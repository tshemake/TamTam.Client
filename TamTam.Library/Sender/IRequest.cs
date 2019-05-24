using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Sender
{
    public interface IRequest<TResponse>
    {
        HttpMethod HttpMethod  { get;set; }
        object Payload { get; set; }
        Uri RequestUri { get; set; }
    }
}
