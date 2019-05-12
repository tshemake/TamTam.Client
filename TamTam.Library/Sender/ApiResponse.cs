using System;
using System.Collections.Generic;
using System.Text;

namespace TamTam.Bot.Sender
{
    public class ApiResponse<TResult> : IApiResponse<TResult>
    {
        public ApiResponse(bool ok, TResult value, ResultInfo info)
        {
            Ok = ok;
            Result = value;
            Info = info;
        }

        public bool Ok { get; private set; }

        public TResult Result { get; private set;  }

        public ResultInfo Info { get; private set; } = new ResultInfo();
    }
}
