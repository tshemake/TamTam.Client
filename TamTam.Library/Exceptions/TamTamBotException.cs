using System;
using System.Collections.Generic;
using System.Text;
using TamTam.Bot.Schema;

namespace TamTam.Bot.Exceptions
{
    public class TamTamBotException : Exception
    {
        public Error Error { get; private set; }

        public TamTamBotException(Error error)
            : this(error, null)
        {
        }

        public TamTamBotException(Error error, Exception innerException)
            : base(error.Message, innerException)
        {
            Error = error;
        }
    }
}
