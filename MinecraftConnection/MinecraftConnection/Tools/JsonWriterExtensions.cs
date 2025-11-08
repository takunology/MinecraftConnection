using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MinecraftConnection.Tools
{
    public static class JsonWriterExtensions
    {
        public static void AppendProperty(this Utf8JsonWriter writer, string name, string? value)
        {
            if (!string.IsNullOrEmpty(value))
                writer.WriteString(name, value);
        }

        public static void AppendProperty(this Utf8JsonWriter writer, string name, int? value)
        {
            if (value.HasValue)
                writer.WriteNumber(name, value.Value);
        }

        public static void AppendProperty(this Utf8JsonWriter writer, string name, double? value)
        {
            if (value.HasValue)
                writer.WriteNumber(name, value.Value);
        }

        public static void AppendProperty<T>(this Utf8JsonWriter writer, string name, IEnumerable<T>? values)
        {
            if (values != null && values.Any())
            {
                writer.WritePropertyName(name);
                writer.WriteStartArray();
                foreach (var v in values)
                    writer.WriteStringValue(v?.ToString());
                writer.WriteEndArray();
            }
        }
    }
}
