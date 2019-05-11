using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTam.Bot.Schema;

namespace TamTam.Bot
{
    public interface IClient
    {
        #region bots

        Task<BotInfo> GetCurrentBotInfoAsync();

        Task<BotInfo> EditCurrentBotInfoAsync(BotPatch botPatch);

        #endregion

        #region chats

        Task<ChatList> GetAllChatsAsync(int limit = 50, long offset = 0);

        Task<Chat> GetChatAsync(long chatId);

        Task<Chat> EditChatInfoAsync(long chatId, ChatPatch chatPatch);

        Task<SimpleQueryResult> SendActionAsync(long chatId, ActionRequestBody action);

        Task<ChatMember> GetChatMembershipAsync(long chatId);

        Task<SimpleQueryResult> LeaveChatAsync(long chatId);

        Task<ChatMembersList> GetMembersAsync(long chatId, IEnumerable<long> userIds = null, int limit = 20, long offset = 0);

        Task<SimpleQueryResult> AddMembersAsync(long chatId, UserIdsList userIds);

        Task<SimpleQueryResult> RemoveMemberAsync(long chatId, long userId);

        #endregion

        #region messages

        Task<MessageList> GetMessagesAsync(long? chatId = null, IEnumerable<long> messageIds = null, long? from = null, long? to = null, long limit = 50);

        Task<SendMessageResult> SendMessageAsync(NewMessageBody message, long? userId = null, long? chatId = null);

        Task<SimpleQueryResult> EditMessageAsync(string messageId, NewMessageBody message);

        Task<SimpleQueryResult> DeleteMessageAsync(string messageId);

        Task<SimpleQueryResult> AnswerOnCallbackAsync(string callbackId, CallbackAnswer answer);

        #endregion

        #region subscriptions

        Task<GetSubscriptionsResult> GetSubscriptionsAsync();

        #endregion
    }
}
