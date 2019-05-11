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

        #endregion

        private static void ThrowIfOutOfInclusiveRange(int value, string name, int minValue, int maxValue)
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
