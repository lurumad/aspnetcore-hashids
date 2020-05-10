using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AspNetCore.Hashids
{
    public class HashidsJsonConverter : JsonConverter<HashidInt>
    {
        public override HashidInt Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string stringValue = reader.GetString();
                return ServiceCollectionExtensions.Hashids.Decode(stringValue)[0];
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt32();
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, HashidInt value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(ServiceCollectionExtensions.Hashids.Encode(value));
        }
    }
}
