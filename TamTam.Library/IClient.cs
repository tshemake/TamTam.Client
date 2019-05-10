using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTam.Bot.Schema;

namespace TamTam.Bot
{
    public interface IClient
    {
        Task<BotInfo> GetCurrentBotInfoAsync();

        Task<BotInfo> EditCurrentBotInfoAsync(BotPatch botPatch);
    }
}
