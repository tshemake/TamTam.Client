using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TamTam.Bot.Sender
{
    public class ResultInfo
    {
        public HttpStatusCode HttpStatusCode { get; }
        public string ErrorCode { get; }
        public string Message { get; set; }
        public Exception Exception { get; }

        public ResultInfo()
        {
        }

        public ResultInfo(Exception exception)
        {
            Exception = exception;
        }

        public ResultInfo(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }

        public ResultInfo(HttpStatusCode httpStatusCode, string errorCode)
            : this(httpStatusCode)
        {
            ErrorCode = errorCode;
        }

        public ResultInfo(HttpStatusCode httpStatusCode, string errorCode, string message)
            : this(httpStatusCode, errorCode)
        {
            Message = message;
        }
    }
}
