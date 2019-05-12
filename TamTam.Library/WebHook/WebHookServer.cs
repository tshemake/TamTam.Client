using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TamTam.Bot.WebHook
{
    public class WebHookServer
    {
        private readonly string _webHookPath;
        private IWebHost _webHost;
        private readonly LogLevel _logLevel;
        private int _eventId = 1;
        public ILogger Logger { get; private set; }
        public int Port { get; private set; }

        public delegate void PostHandler(PostEventArgs e);
        public event PostHandler PostReceived;

        public WebHookServer(int port, string webHookPath, LogLevel level)
        {
            Port = port;
            _logLevel = level;
            _webHookPath = webHookPath;
            CreateWebhookHost();
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            await _webHost.RunAsync(cancellationToken);
        }

        public async Task WaitForShutdownAsync(CancellationToken cancellationToken = default)
        {
            await _webHost.WaitForShutdownAsync(cancellationToken);
        }

        private void CreateWebhookHost()
        {
            var builder = WebHost.CreateDefaultBuilder();

            builder.ConfigureLogging(cfg =>
            {
                cfg.SetMinimumLevel(_logLevel);
            });
            builder.ConfigureServices(cfg =>
            {
                cfg.AddRouting();
            });

            builder.UseKestrel(options =>
            {
                options.Listen(IPAddress.Any, Port);
            });

            builder.Configure(cfg =>
                cfg.UseRouter(r =>
                {
                    r.MapGet(_webHookPath, Post);
                }));

            _webHost = builder.Build();
            Logger = _webHost.Services.GetService<ILoggerFactory>().CreateLogger(GetType().ToString() + $"[{IPAddress.Any}:{Port}]");
        }

        private async Task Post(HttpRequest request, HttpResponse response, RouteData route)
        {
            try
            {
                var eventId = new EventId(_eventId++);

                byte[] buf = new byte[request.ContentLength.Value];
                await request.Body.ReadAsync(buf, 0, buf.Length);

                string body = Encoding.UTF8.GetString(buf);
                Logger.LogDebug(eventId, "WebHook [POST]: " + body);
                if (PostReceived != null)
                {
                    ThreadPool.QueueUserWorkItem(state => PostReceived.Invoke(new PostEventArgs()
                    {
                        Headers = request.Headers,
                        Body = body
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(_eventId, ex, ex.Message);
            }
        }
    }
}
