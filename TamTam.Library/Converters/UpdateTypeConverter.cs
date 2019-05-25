using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TamTam.Bot.Schema;

namespace TamTam.Bot.Converters
{
    public class UpdateTypeConverter : JsonConverter
    {
        public static readonly UpdateTypeConverter Singleton = new UpdateTypeConverter();

        private readonly string _discriminatorName;

        [ThreadStatic]
        private static bool _isReading;

        [ThreadStatic]
        private static bool _isWriting;

        public UpdateTypeConverter()
        {
            _discriminatorName = "update_type";
        }

        public override bool CanWrite
        {
            get
            {
                if (!_isWriting)
                {
                    return true;
                }

                return _isWriting = false;
            }
        }

        public override bool CanRead
        {
            get
            {
                if (!_isReading)
                {
                    return true;
                }

                return _isReading = false;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(Update);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;

            var jsonObject = serializer.Deserialize<JObject>(reader);
            if (jsonObject == null) return null;

            var discriminator = Extensions.Value<string>(jsonObject.GetValue(_discriminatorName));
            Type subType = GetObjectSubtype(objectType, discriminator);
            if (subType == null) return null;

            try
            {
                _isReading = true;
                return serializer.Deserialize(jsonObject.CreateReader(), subType);
            }
            finally
            {
                _isReading = false;
            }
        }

        private Type GetObjectSubtype(Type objectType, string discriminator)
        {
            switch (GetEnumValueFromEnumMemberValue<UpdateType>(discriminator))
            {
                case UpdateType.MessageCreated:
                    return typeof(MessageCreated);
            }

            return objectType;
        }

        public static T GetEnumValueFromEnumMemberValue<T>(string enumMemberValue)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                            .SelectMany(f => f.GetCustomAttributes(
                                typeof(EnumMemberAttribute), false), (
                                    f, a) => new { Field = f, Att = a })
                            .Where(a => ((EnumMemberAttribute)a.Att)
                                .Value == enumMemberValue).SingleOrDefault();
            return field == null ? default : (T)field.Field.GetRawConstantValue();
        }
    }
}
