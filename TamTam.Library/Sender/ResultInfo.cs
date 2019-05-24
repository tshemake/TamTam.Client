using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TamTam.Bot.Sender
{
    public class ResultInfo
    {
        public HttpStatus HttpStatus { get; }
        public string Code { get; }
        public string Message { get; set; }
        public Exception Exception { get; }

        public ResultInfo()
        {
            HttpStatus = default;
            Code = default;
            Message = default;
            Exception = default;
        }

        public ResultInfo(Exception exception)
        {
            Exception = exception;
        }

        public ResultInfo(HttpStatus httpStatus)
        {
            HttpStatus = httpStatus;
        }

        public ResultInfo(HttpStatus httpStatus, string code)
            : this(httpStatus)
        {
            Code = code;
        }

        public ResultInfo(HttpStatus httpStatus, string code, string message)
            : this(httpStatus, code)
        {
            Message = message;
        }
    }
}
