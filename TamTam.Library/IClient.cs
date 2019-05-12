using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TamTam.Bot.Schema;
using TamTam.Bot.Sender;

namespace TamTam.Bot
{
    public interface IClient
    {
        #region log

        ILogger Logger { get; }

        void SetLogLevel(LogLevel logLevel);

        #endregion

        #region bots

        Task<IApiResponse<BotInfo>> GetCurrentBotInfoAsync(CancellationToken cancellationToken = default);

        Task<IApiResponse<BotInfo>> EditCurrentBotInfoAsync(BotPatch botPatch, CancellationToken cancellationToken = default);

        #endregion

        #region chats

        Task<IApiResponse<ChatList>> GetAllChatsAsync(int limit = 50, long offset = 0, CancellationToken cancellationToken = default);

        Task<IApiResponse<Chat>> GetChatAsync(long chatId, CancellationToken cancellationToken = default);

        Task<IApiResponse<Chat>> EditChatInfoAsync(long chatId, ChatPatch chatPatch, CancellationToken cancellationToken = default);

        Task<IApiResponse<SimpleQueryResult>> SendActionAsync(long chatId, ActionRequestBody action, CancellationToken cancellationToken = default);

        Task<IApiResponse<ChatMember>> GetChatMembershipAsync(long chatId, CancellationToken cancellationToken = default);

        Task<IApiResponse<SimpleQueryResult>> LeaveChatAsync(long chatId, CancellationToken cancellationToken = default);

        Task<IApiResponse<ChatMembersList>> GetMembersAsync(long chatId, IEnumerable<long> userIds = null, int limit = 20, long offset = 0, CancellationToken cancellationToken = default);

        Task<IApiResponse<SimpleQueryResult>> AddMembersAsync(long chatId, UserIdsList userIds, CancellationToken cancellationToken = default);

        Task<IApiResponse<SimpleQueryResult>> RemoveMemberAsync(long chatId, long userId, CancellationToken cancellationToken = default);

        #endregion

        #region messages

        Task<IApiResponse<MessageList>> GetMessagesAsync(long? chatId = null, IEnumerable<long> messageIds = null, long? from = null, long? to = null, long limit = 50, CancellationToken cancellationToken = default);

        Task<IApiResponse<SendMessageResult>> SendMessageAsync(NewMessageBody message, long? userId = null, long? chatId = null, CancellationToken cancellationToken = default);

        Task<IApiResponse<SimpleQueryResult>> EditMessageAsync(string messageId, NewMessageBody message, CancellationToken cancellationToken = default);

        Task<IApiResponse<SimpleQueryResult>> DeleteMessageAsync(string messageId, CancellationToken cancellationToken = default);

        Task<IApiResponse<SimpleQueryResult>> AnswerOnCallbackAsync(string callbackId, CallbackAnswer answer, CancellationToken cancellationToken = default);

        #endregion

        #region subscriptions

        Task<IApiResponse<GetSubscriptionsResult>> GetSubscriptionsAsync(CancellationToken cancellationToken = default);

        Task<IApiResponse<SimpleQueryResult>> SubscribeAsync(SubscriptionRequestBody subscriptionRequest, CancellationToken cancellationToken = default);

        Task<IApiResponse<SimpleQueryResult>> UnsubscribeAsync(string url, CancellationToken cancellationToken = default);

        Task<IApiResponse<UpdateList>> GetUpdatesAsync(long limit = 100, long? offset = null, IEnumerable<UpdateType> types = null, long timeout = 30, CancellationToken cancellationToken = default);

        #endregion

        #region upload

        Task<IApiResponse<UploadEndpoint>> GetUploadUrlAsync(UploadType type, CancellationToken cancellationToken = default);

        #endregion
    }
}
