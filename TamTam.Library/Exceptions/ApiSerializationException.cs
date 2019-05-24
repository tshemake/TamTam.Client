using System;
using System.Collections.Generic;
using System.Text;

namespace TamTam.Bot.Exceptions
{
    public class ApiSerializationException : Exception
    {
        public ApiSerializationException()
        {
        }

        public ApiSerializationException(string message)
            : base(message)
        {
        }

        public ApiSerializationException(string message, string content)
            : base(message)
        {
            Content = content;
        }

        public ApiSerializationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ApiSerializationException(string message, string content, Exception innerException)
            : base(message, innerException)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}
