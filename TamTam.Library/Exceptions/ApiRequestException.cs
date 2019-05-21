using System;
using System.Collections.Generic;
using System.Text;

namespace TamTam.Bot.Exceptions
{
    public class ApiRequestException : Exception
    {
        public virtual int ErrorCode { get; }

        public ApiRequestException(string message, int errorCode, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
