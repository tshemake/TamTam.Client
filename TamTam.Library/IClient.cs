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

        Task<Chat> GetChatAsync(int chatId);

        Task<Chat> EditChatInfoAsync(int chatId, ChatPatch chatPatch);

        Task<SimpleQueryResult> SendActionAsync(int chatId, ActionRequestBody action);

        Task<ChatMember> GetChatMembershipAsync(int chatId);

        Task<SimpleQueryResult> LeaveChatAsync(int chatId);

        Task<ChatMembersList> GetMembersAsync(int chatId, IEnumerable<long> userIds = null, int limit = 20, long offset = 0);

        Task<SimpleQueryResult> AddMembersAsync(int chatId, UserIdsList userIds);

        Task<SimpleQueryResult> RemoveMemberAsync(int chatId, long userId);

        #endregion

        #region messages

        Task<MessageList> GetMessagesAsync(int? chatId = null, IEnumerable<long> messageIds = null, long? from = null, long? to = null, long limit = 50);

        #endregion
    }
}
