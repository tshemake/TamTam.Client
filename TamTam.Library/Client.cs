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
    }
}
