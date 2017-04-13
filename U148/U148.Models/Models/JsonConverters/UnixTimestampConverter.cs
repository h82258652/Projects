using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace U148.Models.JsonConverters
{
    public class UnixTimestampConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenType = reader.TokenType;
            if (tokenType == JsonToken.Integer)
            {
                var timestamp = (long)reader.Value;
                return DateTimeOffset.FromUnixTimeSeconds(timestamp);
            }
            else if (tokenType == JsonToken.String)
            {
                if (long.TryParse((string)reader.Value, out long timestamp))
                {
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
    }
}