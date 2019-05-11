﻿using System;
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
    }
}
