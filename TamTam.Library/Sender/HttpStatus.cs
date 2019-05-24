using System;
using System.Collections.Generic;
using System.Text;

namespace TamTam.Bot.Sender
{
    public class HttpStatus
    {
        public int? StatusCode { get; set; }
        public object Body { get; set; }

        public HttpStatus(int? statusCode = default, object body = default)
        {
            StatusCode = statusCode;
            Body = body;
        }
    }
}
