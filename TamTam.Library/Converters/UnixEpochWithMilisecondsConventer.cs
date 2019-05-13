using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Converters
{
    public class UnixEpochWithMilisecondsConventer : JsonConverter
    {
        private readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value.ToString() == "0" || reader.Value == null)
            {
                return null;
            }
            if (reader.Value.ToString().StartsWith("-"))
            {
                return null;
            }
            return _epoch.AddMilliseconds(Convert.ToInt64(reader.Value));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var date = ((DateTime)value).ToUniversalTime();
            var delta = date.Subtract(_epoch);

            writer.WriteValue(Convert.ToInt64(Math.Truncate(delta.TotalMilliseconds)));
        }
    }
}
