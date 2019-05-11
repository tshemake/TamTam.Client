using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TamTam.Bot.Schema;

namespace TamTam.Bot
{
    public class Client : IClient
    {
        private readonly string _accessToken;

        public Client(string accessToken)
        {
            _accessToken = accessToken;
        }

        #region bots

        /// <summary>
        /// Get current bot info.
        /// </summary>
        public async Task<BotInfo> GetCurrentBotInfoAsync()
        {
            BotInfo result = null;
            using (var client = new HttpClient())
            using (var response = await client.GetAsync($"https://botapi.tamtam.chat/me?access_token={_accessToken}"))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<BotInfo>(body);
                }
            }

            return result;
        }

        /// <summary>
        /// Edit current bot info.
        /// </summary>
        public async Task<BotInfo> EditCurrentBotInfoAsync(BotPatch botPatch)
        {
            BotInfo result = null;
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, $"https://botapi.tamtam.chat/me?access_token={_accessToken}")
            {
                Content = new StringContent(JsonConvert.SerializeObject(botPatch), Encoding.UTF8, "application/json")
            };
            using (var client = new HttpClient())
            using (var response = await client.SendAsync(request))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<BotInfo>(body);
                }
            }

            return result;
        }

        #endregion

        #region chats

        /// <summary>
        /// Get all chats.
        /// </summary>
        public async Task<ChatList> GetAllChatsAsync(int limit = 50, long offset = 0)
        {
            ThrowIfOutOfInclusiveRange(limit, nameof(limit), 1, 100);
            ChatList result = null;
            using (var client = new HttpClient())
            using (var response = await client.GetAsync($"https://botapi.tamtam.chat/chats?access_token={_accessToken}&count={limit}&marker={offset}"))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ChatList>(body);
                }
            }

            return result;
        }

        /// <summary>
        /// Get chat.
        /// </summary>
        public async Task<Chat> GetChatAsync(int chatId)
        {
            Chat result = null;
            using (var client = new HttpClient())
            using (var response = await client.GetAsync($"https://botapi.tamtam.chat/chats/{chatId}?access_token={_accessToken}"))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Chat>(body);
                }
            }

            return result;
        }

        /// <summary>
        /// Edit chat info.
        /// </summary>
        public async Task<Chat> EditChatInfoAsync(int chatId, ChatPatch chatPatch)
        {
            Chat result = null;
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, $"https://botapi.tamtam.chat/chats/{chatId}?access_token={_accessToken}")
            {
                Content = new StringContent(JsonConvert.SerializeObject(chatPatch), Encoding.UTF8, "application/json")
            };
            using (var client = new HttpClient())
            using (var response = await client.SendAsync(request))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Chat>(body);
                }
            }

            return result;
        }

        /// <summary>
        /// Send action.
        /// </summary>
        public async Task<SimpleQueryResult> SendActionAsync(int chatId, ActionRequestBody action)
        {
            SimpleQueryResult result = null;
            var content = new StringContent(JsonConvert.SerializeObject(action), Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            using (var response = await client.PostAsync($"https://botapi.tamtam.chat/chats/{chatId}/actions?access_token={_accessToken}", content))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SimpleQueryResult>(body);
                }
            }

            return result;
        }

        /// <summary>
        /// Get chat membership.
        /// </summary>
        public async Task<ChatMember> GetChatMembershipAsync(int chatId)
        {
            ChatMember result = null;
            using (var client = new HttpClient())
            using (var response = await client.GetAsync($"https://botapi.tamtam.chat/chats/{chatId}/members/me?access_token={_accessToken}"))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ChatMember>(body);
                }
            }

            return result;
        }

        /// <summary>
        /// Leave chat.
        /// </summary>
        public async Task<SimpleQueryResult> LeaveChatAsync(int chatId)
        {
            SimpleQueryResult result = null;
            using (var client = new HttpClient())
            using (var response = await client.DeleteAsync($"https://botapi.tamtam.chat/chats/{chatId}/members/me?access_token={_accessToken}"))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SimpleQueryResult>(body);
                }
            }

            return result;
        }

        /// <summary>
        /// Get members.
        /// </summary>
        public async Task<ChatMembersList> GetMembersAsync(int chatId, IEnumerable<long> userIds = null, int limit = 20, long offset = 0)
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
            ChatMembersList result = null;
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(requireUrl))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ChatMembersList>(body);
                }
            }

            return result;
        }

        /// <summary>
        /// Add members.
        /// </summary>
        public async Task<SimpleQueryResult> AddMembersAsync(int chatId, UserIdsList userIds)
        {
            SimpleQueryResult result = null;
            var content = new StringContent(JsonConvert.SerializeObject(userIds), Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            using (var response = await client.PostAsync($"https://botapi.tamtam.chat/chats/{chatId}/members?access_token={_accessToken}", content))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SimpleQueryResult>(body);
                }
            }

            return result;
        }

        /// <summary>
        /// Remove member.
        /// </summary>
        public async Task<SimpleQueryResult> RemoveMemberAsync(int chatId, long userId)
        {
            SimpleQueryResult result = null;
            using (var client = new HttpClient())
            using (var response = await client.DeleteAsync($"https://botapi.tamtam.chat/chats/{chatId}/members?access_token={_accessToken}&user_id={userId}"))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SimpleQueryResult>(body);
                }
            }

            return result;
        }

        #endregion

        #region messages

        public async Task<MessageList> GetMessagesAsync(int? chatId = null, IEnumerable<long> messageIds = null, long? from = null, long? to = null, long limit = 50)
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
            MessageList result = null;
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(requireUrl))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<MessageList>(body);
                }
            }

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
    }
}
