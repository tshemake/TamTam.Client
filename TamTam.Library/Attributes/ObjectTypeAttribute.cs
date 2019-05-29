using System;
using System.Collections.Generic;
using System.Text;

namespace TamTam.Bot.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ObjectTypeAttribute : Attribute
    {
        public ObjectTypeAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
    }
}
