using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TamTam.Bot.Sender
{
    public class ResultInfo
    {
        public HttpStatus HttpStatus { get; }
        public Exception Exception { get; }

        public ResultInfo()
        {
            HttpStatus = default;
            Exception = default;
        }

        public ResultInfo(HttpStatus httpStatus)
        {
            HttpStatus = httpStatus;
        }

        public ResultInfo(HttpStatus httpStatus, Exception exception)
            : this(httpStatus)
        {
            Exception = exception;
        }
    }
}
