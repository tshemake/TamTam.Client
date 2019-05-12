using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TamTam.Bot.Connector;
using TamTam.Bot.Schema;
using TamTam.Bot.Sender;

namespace TamTam.Bot
{
    public class Client : IClient
    {
        public readonly Version ApiVersion = new Version(0, 1, 6);

#if DEBUG
        private readonly LogLevel DefaultLogLevel = LogLevel.Debug;
#else
        private readonly LogLevel DefaultLogLevel = LogLevel.Information;
#endif

        private LogLevel _logLevel;

        public ILogger Logger { get; private set; }

        private readonly string _accessToken;
        private readonly IConnectorClient _connectorClient;

        public Client(string accessToken)
            : this(accessToken, new HttpClientFactory())
        {
        }

        public Client(string accessToken, HttpClientFactory httpClientFactory)
        {
            _accessToken = accessToken;
            _connectorClient = new ConnectorClient(httpClientFactory);
            _logLevel = DefaultLogLevel;
        }

        public void SetLogLevel(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }

        #region bots

        /// <summary>
        /// Get current bot info.
        /// </summary>
        public async Task<IApiResponse<BotInfo>> GetCurrentBotInfoAsync(CancellationToken cancellationToken = default)
        {
            IApiResponse<BotInfo> result = null;
            result = await SenderApi.GetAsync<BotInfo>(_connectorClient, $"https://botapi.tamtam.chat/me?access_token={_accessToken}", cancellationToken);
            return result;
        }

        /// <summary>
        /// Edit current bot info.
        /// </summary>
        public async Task<IApiResponse<BotInfo>> EditCurrentBotInfoAsync(BotPatch botPatch, CancellationToken cancellationToken = default)
        {
            IApiResponse<BotInfo> result = null;
            result = await SenderApi.PatchAsync<BotInfo>(_connectorClient, $"https://botapi.tamtam.chat/me?access_token={_accessToken}", botPatch, cancellationToken);
            return result;
        }

        #endregion

        #region chats

        /// <summary>
        /// Get all chats.
        /// </summary>
        public async Task<IApiResponse<ChatList>> GetAllChatsAsync(int limit = 50, long offset = 0, CancellationToken cancellationToken = default)
        {
            ThrowIfOutOfInclusiveRange(limit, nameof(limit), 1, 100);
            IApiResponse<ChatList> result = null;
            result = await SenderApi.GetAsync<ChatList>(_connectorClient, $"https://botapi.tamtam.chat/chats?access_token={_accessToken}&count={limit}&marker={offset}", cancellationToken);
            return result;
        }

        /// <summary>
        /// Get chat.
        /// </summary>
        public async Task<IApiResponse<Chat>> GetChatAsync(long chatId, CancellationToken cancellationToken = default)
        {
            IApiResponse<Chat> result = null;
            result = await SenderApi.GetAsync<Chat>(_connectorClient, $"https://botapi.tamtam.chat/chats/{chatId}?access_token={_accessToken}", cancellationToken);
            return result;
        }

        /// <summary>
        /// Edit chat info.
        /// </summary>
        public async Task<IApiResponse<Chat>> EditChatInfoAsync(long chatId, ChatPatch chatPatch, CancellationToken cancellationToken = default)
        {
            IApiResponse<Chat> result = null;
            result = await SenderApi.PatchAsync<Chat>(_connectorClient, $"https://botapi.tamtam.chat/chats/{chatId}?access_token={_accessToken}", chatPatch, cancellationToken);
            return result;
        }

        /// <summary>
        /// Send action.
        /// </summary>
        public async Task<IApiResponse<SimpleQueryResult>> SendActionAsync(long chatId, ActionRequestBody action, CancellationToken cancellationToken = default)
        {
            IApiResponse<SimpleQueryResult> result = null;
            result = await SenderApi.PostAsync<SimpleQueryResult>(_connectorClient, $"https://botapi.tamtam.chat/chats/{chatId}/actions?access_token={_accessToken}", action, cancellationToken);
            return result;
        }

        /// <summary>
        /// Get chat membership.
        /// </summary>
        public async Task<IApiResponse<ChatMember>> GetChatMembershipAsync(long chatId, CancellationToken cancellationToken = default)
        {
            IApiResponse<ChatMember> result = null;
            result = await SenderApi.GetAsync<ChatMember>(_connectorClient, $"https://botapi.tamtam.chat/chats/{chatId}/members/me?access_token={_accessToken}", cancellationToken);
            return result;
        }

        /// <summary>
        /// Leave chat.
        /// </summary>
        public async Task<IApiResponse<SimpleQueryResult>> LeaveChatAsync(long chatId, CancellationToken cancellationToken = default)
        {
            IApiResponse<SimpleQueryResult> result = null;
            result = await SenderApi.DeleteAsync<SimpleQueryResult>(_connectorClient, $"https://botapi.tamtam.chat/chats/{chatId}/members/me?access_token={_accessToken}", cancellationToken);
            return result;
        }

        /// <summary>
        /// Get members.
        /// </summary>
        public async Task<IApiResponse<ChatMembersList>> GetMembersAsync(long chatId, IEnumerable<long> userIds = null, int limit = 20, long offset = 0, CancellationToken cancellationToken = default)
        {
            var requireUrl = $"https://botapi.tamtam.chat/chats/{chatId}/members?access_token={_accessToken}";
            if (userIds != null)
            {
                requireUrl += "&user_ids=" + string.Join(",", userIds);
            }
            else
            {
                ThrowIfOutOfInclusiveRange(limit, nameof(limit), 1, 100);
                requireUrl += $"&count={limit}&marker={offset}";
            }
            IApiResponse<ChatMembersList> result = null;
            result = await SenderApi.DeleteAsync<ChatMembersList>(_connectorClient, requireUrl, cancellationToken);
            return result;
        }

        /// <summary>
        /// Add members.
        /// </summary>
        public async Task<IApiResponse<SimpleQueryResult>> AddMembersAsync(long chatId, UserIdsList userIds, CancellationToken cancellationToken = default)
        {
            IApiResponse<SimpleQueryResult> result = null;
            result = await SenderApi.PostAsync<SimpleQueryResult>(_connectorClient, $"https://botapi.tamtam.chat/chats/{chatId}/members?access_token={_accessToken}", userIds, cancellationToken);
            return result;
        }

        /// <summary>
        /// Remove member.
        /// </summary>
        public async Task<IApiResponse<SimpleQueryResult>> RemoveMemberAsync(long chatId, long userId, CancellationToken cancellationToken = default)
        {
            IApiResponse<SimpleQueryResult> result = null;
            result = await SenderApi.DeleteAsync<SimpleQueryResult>(_connectorClient, $"https://botapi.tamtam.chat/chats/{chatId}/members?access_token={_accessToken}&user_id={userId}", cancellationToken);
            return result;
        }

        #endregion

        #region messages

        /// <summary>
        /// Get messages.
        /// </summary>
        public async Task<IApiResponse<MessageList>> GetMessagesAsync(long? chatId = null, IEnumerable<long> messageIds = null, long? from = null, long? to = null, long limit = 50, CancellationToken cancellationToken = default)
        {
            var requireUrl = $"https://botapi.tamtam.chat/messages?access_token={_accessToken}";
            if (chatId.HasValue)
            {
                requireUrl += $"&chat_id={chatId.Value}";
            }
            if (messageIds != null)
            {
                requireUrl += "&message_ids=" + string.Join(",", messageIds);
            }
            if (from.HasValue)
            {
                requireUrl += $"&from={from.Value}";
            }
            if (to.HasValue)
            {
                requireUrl += $"&to={to.Value}";
            }
            ThrowIfOutOfInclusiveRange(limit, nameof(limit), 1, 100);
            requireUrl += $"&count={limit}";
            IApiResponse<MessageList> result = null;
            result = await SenderApi.GetAsync<MessageList>(_connectorClient, requireUrl, cancellationToken);
            return result;
        }

        /// <summary>
        /// Send message.
        /// </summary>
        public async Task<IApiResponse<SendMessageResult>> SendMessageAsync(NewMessageBody message, long? userId = null, long? chatId = null, CancellationToken cancellationToken = default)
        {
            var requireUrl = $"https://botapi.tamtam.chat/messages?access_token={_accessToken}";
            if (userId.HasValue)
            {
                requireUrl += $"&user_id={userId.Value}";
            }
            if (chatId.HasValue)
            {
                requireUrl += $"&chat_id={chatId.Value}";
            }
            IApiResponse<SendMessageResult> result = null;
            result = await SenderApi.PostAsync<SendMessageResult>(_connectorClient, requireUrl, message, cancellationToken);
            return result;
        }

        /// <summary>
        /// Edit message.
        /// </summary>
        public async Task<IApiResponse<SimpleQueryResult>> EditMessageAsync(string messageId, NewMessageBody message, CancellationToken cancellationToken = default)
        {
            IApiResponse<SimpleQueryResult> result = null;
            result = await SenderApi.PutAsync<SimpleQueryResult>(_connectorClient, $"https://botapi.tamtam.chat/messages?access_token={_accessToken}&message_id={messageId}", message, cancellationToken);
            return result;
        }

        /// <summary>
        /// Delete message.
        /// </summary>
        public async Task<IApiResponse<SimpleQueryResult>> DeleteMessageAsync(string messageId, CancellationToken cancellationToken = default)
        {
            IApiResponse<SimpleQueryResult> result = null;
            result = await SenderApi.DeleteAsync<SimpleQueryResult>(_connectorClient, $"https://botapi.tamtam.chat/messages?access_token={_accessToken}&message_id={messageId}", cancellationToken);
            return result;
        }

        /// <summary>
        /// Answer on callback.
        /// </summary>
        public async Task<IApiResponse<SimpleQueryResult>> AnswerOnCallbackAsync(string callbackId, CallbackAnswer answer, CancellationToken cancellationToken = default)
        {
            IApiResponse<SimpleQueryResult> result = null;
            result = await SenderApi.PostAsync<SimpleQueryResult>(_connectorClient, $"https://botapi.tamtam.chat/answers?access_token={_accessToken}&callback_id={callbackId}", answer, cancellationToken);
            return result;
        }

        #endregion

        #region subscriptions

        /// <summary>
        /// Get subscriptions.
        /// </summary>
        /// <returns></returns>
        public async Task<IApiResponse<GetSubscriptionsResult>> GetSubscriptionsAsync(CancellationToken cancellationToken = default)
        {
            IApiResponse<GetSubscriptionsResult> result = null;
            result = await SenderApi.GetAsync<GetSubscriptionsResult>(_connectorClient, $"https://botapi.tamtam.chat/subscriptions?access_token={_accessToken}", cancellationToken);
            return result;
        }

        public async Task<IApiResponse<SimpleQueryResult>> SubscribeAsync(SubscriptionRequestBody subscriptionRequest, CancellationToken cancellationToken = default)
        {
            IApiResponse<SimpleQueryResult> result = null;
            result = await SenderApi.PostAsync<SimpleQueryResult>(_connectorClient, $"https://botapi.tamtam.chat/subscriptions?access_token={_accessToken}", subscriptionRequest, cancellationToken);
            return result;
        }

        /// <summary>
        /// Unsubscribe.
        /// </summary>
        public async Task<IApiResponse<SimpleQueryResult>> UnsubscribeAsync(string url, CancellationToken cancellationToken = default)
        {
            IApiResponse<SimpleQueryResult> result = null;
            result = await SenderApi.DeleteAsync<SimpleQueryResult>(_connectorClient, $"https://botapi.tamtam.chat/subscriptions?access_token={_accessToken}&url={url}", cancellationToken);
            return result;
        }

        /// <summary>
        /// Get updates.
        /// </summary>
        public async Task<IApiResponse<UpdateList>> GetUpdatesAsync(long limit = 100, long? offset = null, IEnumerable<UpdateType> types = null, long timeout = 30, CancellationToken cancellationToken = default)
        {
            ThrowIfOutOfInclusiveRange(limit, nameof(limit), 1, 1000);
            ThrowIfOutOfInclusiveRange(timeout, nameof(timeout), 0, 90);

            var requireUrl = $"https://botapi.tamtam.chat/updates?access_token={_accessToken}";
            requireUrl += $"&limit={limit}&timeout={timeout}";
            if (offset.HasValue)
            {
                requireUrl += $"&marker={offset}";
            }
            if (types != null)
            {
                requireUrl += $"&types=" + string.Join(",", types.Select(type => ToEnumString(type)));
            }
            IApiResponse<UpdateList> result = null;
            result = await SenderApi.GetAsync<UpdateList>(_connectorClient, requireUrl, cancellationToken);
            return result;
        }

        #endregion

        #region upload

        /// <summary>
        /// Get upload URL.
        /// </summary>
        public async Task<IApiResponse<UploadEndpoint>> GetUploadUrlAsync(UploadType type, CancellationToken cancellationToken = default)
        {
            var requireUrl = $"https://botapi.tamtam.chat/uploads?access_token={_accessToken}";
            requireUrl += $"&type=" + ToEnumString(type);

            IApiResponse<UploadEndpoint> result = null;
            result = await SenderApi.PostAsync<UploadEndpoint>(_connectorClient, requireUrl, null, cancellationToken);
            return result;
        }

        public async Task<IApiResponse<PhotoTokenList>> UploadPhotoAsync(string requireUrl, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            IApiResponse<PhotoTokenList> result = null;
            result = await SenderApi.UploadPhotoAsync(_connectorClient, requireUrl, assetName, stream, cancellationToken);
            return result;
        }

        public async Task<IApiResponse<UploadedInfo>> UploadVideoAsync(string requireUrl, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            IApiResponse<UploadedInfo> result = null;
            result = await SenderApi.UploadVideoAsync(_connectorClient, requireUrl, assetName, stream, cancellationToken);
            return result;
        }

        public async Task<IApiResponse<UploadedInfo>> UploadAudioAsync(string requireUrl, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            IApiResponse<UploadedInfo> result = null;
            result = await SenderApi.UploadAudioAsync(_connectorClient, requireUrl, assetName, stream, cancellationToken);
            return result;
        }

        public async Task<IApiResponse<UploadedFileInfo>> UploadFileAsync(string requireUrl, string assetName, Stream stream, CancellationToken cancellationToken = default)
        {
            IApiResponse<UploadedFileInfo> result = null;
            result = await SenderApi.UploadFileAsync(_connectorClient, requireUrl, assetName, stream, cancellationToken);
            return result;
        }

        #endregion

        private static void ThrowIfOutOfInclusiveRange(long value, string name, long minValue, long maxValue)
        {
            if (value < minValue && value > maxValue)
            {
                throw new ArgumentOutOfRangeException(
                    name,
                    value,
                    string.Format("Value must be between {0} and {1}.", minValue, maxValue));
            }
        }

        private static string ToEnumString<T>(T instance)
        {
            if (!(instance is Enum)) throw new ArgumentException(nameof(instance), "Must be enum type");
            var field = typeof(T).GetField(instance.ToString());
            if (field != null)
            {
                var attr = (EnumMemberAttribute)field.GetCustomAttributes(typeof(EnumMemberAttribute), false).SingleOrDefault();
                if (attr != default) return attr.Value;
            }
            return null;
        }
    }
}
