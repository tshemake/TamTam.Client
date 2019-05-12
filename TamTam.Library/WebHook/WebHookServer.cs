using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace TamTam.Bot.WebHook
{
    public class WebHookServer
    {
        private IWebHost _host;
        private LogLevel _logLevel;
        public int Port { get; private set; }

        public WebHookServer(int port, LogLevel level)
        {
            Port = port;
            _logLevel = level;
            CreateWebhookHost();
        }

        private void CreateWebhookHost()
        {
            var builder = WebHost.CreateDefaultBuilder();

            builder.ConfigureLogging(cfg =>
            {
                cfg.SetMinimumLevel(_logLevel);
            });

            builder.UseKestrel(options =>
            {
                options.Listen(IPAddress.Any, Port);
            });

            _host = builder.Build();
        }
    }
}
