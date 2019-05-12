using System;
using System.Collections.Generic;
using System.Text;

namespace TamTam.Bot.Sender
{
    public interface IApiResponse<TResult>
    {
        bool Ok { get;}
        TResult Result { get; }
        ResultInfo Info { get; }
    }
}
