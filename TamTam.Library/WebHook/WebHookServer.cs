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
using Microsoft.AspNetCore.Hosting.Server.Features;

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

        public async Task RunAsync(CancellationToken cancellationToken = default)
        {
            using (_webHost)
            {
                await _webHost.RunAsync(cancellationToken);
                var serverAddresses = _webHost.ServerFeatures.Get<IServerAddressesFeature>()?.Addresses;
                if (serverAddresses != null)
                {
                    foreach (var address in serverAddresses)
                    {
                        Logger.LogInformation($"Now listening on: {address}");
                    }
                }
                await _webHost.WaitForShutdownAsync(cancellationToken);
                Logger.LogInformation("Stopping WebHookServer");
            }
        }

        private void CreateWebhookHost()
        {
            var builder = WebHost.CreateDefaultBuilder();

            builder.ConfigureLogging(cfg =>
            {
                cfg.SetMinimumLevel(_logLevel);
                cfg.AddConsole();
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
                    r.MapPost(_webHookPath, Post);
                }));

            _webHost = builder.Build();
            Logger = _webHost.Services.GetService<ILoggerFactory>().CreateLogger(GetType().ToString() + $"[{IPAddress.Any}:{Port}]");
        }

        private async Task Post(HttpRequest request, HttpResponse response, RouteData route)
        {
            try
            {
                var eventId = new EventId(_eventId++);

                string body = await ReadBodyAsStringAsync(request);
                Logger.LogDebug(eventId, "WebHook [POST]: " + body);
                if (PostReceived != null)
                {
                    OnPostsReceived(new PostEventArgs()
                    {
                        Headers = request.Headers,
                        Body = body
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(_eventId, ex, ex.Message);
            }
        }

        private static async Task<string> ReadBodyAsStringAsync(HttpRequest request)
        {
            if (!request.ContentLength.HasValue) return null;
            else
            {
                var data = new byte[request.ContentLength.Value];
                await request.Body.ReadAsync(data, 0, data.Length);

                return Encoding.UTF8.GetString(data);
            }
        }

        protected virtual void OnPostsReceived(PostEventArgs postEvent)
        {
            ThreadPool.QueueUserWorkItem(state => PostReceived.Invoke(postEvent));
        }
    }
}
