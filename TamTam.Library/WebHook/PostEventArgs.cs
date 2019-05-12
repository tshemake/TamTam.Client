using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TamTam.Bot.WebHook
{
    public class PostEventArgs : EventArgs
    {
        public IHeaderDictionary Headers { get; set; }

        public string Body { get; set; }
    }
}
