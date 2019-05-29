using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TamTam.Bot.Attributes;
using TamTam.Bot.Schema;

namespace TamTam.Bot.Converters
{
    public class JsonInheritanceConverter : JsonConverter
    {
        internal static readonly string DefaultDiscriminatorName = "discriminator";

        private readonly string _propertyName;

        [ThreadStatic]
        private static bool _isReading;

        [ThreadStatic]
        private static bool _isWriting;

        public JsonInheritanceConverter()
            : this(DefaultDiscriminatorName)
        {
        }

        public JsonInheritanceConverter(string discriminator)
        {
            _propertyName = discriminator;
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
            var enumMemberValue = Extensions.Value<string>(jsonObject.GetValue(_propertyName));
            if (enumMemberValue == null) return null;
            Type subType = GetObjectType(objectType, enumMemberValue);
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

        private Type GetObjectType(Type objectType, string enumMemberValue)
        {
            var type = typeof(UpdateType);
            var memInfo = type.GetMember(GetEnumValueFromEnumMemberValue<UpdateType>(enumMemberValue).ToString());
            var mem = memInfo.FirstOrDefault(m => m.DeclaringType == type);
            var attribute = (ObjectTypeAttribute)mem.GetCustomAttributes(typeof(ObjectTypeAttribute), false).FirstOrDefault();
            if (attribute != default)
            {
                return attribute.Type;
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
