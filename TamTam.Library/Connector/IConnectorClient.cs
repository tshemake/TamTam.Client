using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TamTam.Bot.Connector
{
    public interface IConnectorClient
    {
        Uri BaseUri { get; }

        HttpClient HttpClient { get; }
    }
}
