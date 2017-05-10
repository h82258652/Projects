using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VGtime.Models.JsonConverters
{
    public class UnixTimestampConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenType = reader.TokenType;
            if (tokenType == JsonToken.Integer)
            {
                var timestamp = (long)reader.Value;
                if (timestamp == 0 && IsNullable(objectType))
                {
                    return null;
                }
                return DateTimeOffset.FromUnixTimeSeconds(timestamp);
            }
            else if (tokenType == JsonToken.String)
            {
                if (long.TryParse((string)reader.Value, out long timestamp))
                {
                    if (timestamp == 0 && IsNullable(objectType))
                    {
                        return null;
                    }
                    return DateTimeOffset.FromUnixTimeSeconds(timestamp);
                }
                else
                {
                    throw new JsonSerializationException(Properties.Resources.NotSupportStringFormatExceptionMessage);
                }
            }
            else
            {
                throw new JsonSerializationException(Properties.Resources.NotSupportValueTypeExceptionMessage);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var timestamp = (DateTimeOffset)value;
            writer.WriteValue(timestamp.ToUnixTimeSeconds());
        }

        private static bool IsNullable(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return type != null && typeInfo.IsValueType && typeInfo.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}