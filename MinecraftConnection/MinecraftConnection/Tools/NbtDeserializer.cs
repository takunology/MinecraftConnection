using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MinecraftConnection.Tools
{
    public static class NbtDeserializer
    {
        public static string NormalizeToJson(string input)
        {
            int start = input.IndexOf('{');
            if (start == -1) return string.Empty;
            input = input.Substring(start).Replace("\"", "");

            input = Regex.Replace(input, @"(\w+):", "\"$1\":");
            input = Regex.Replace(input, @"(\d+)([bBsSlLfFdD])", "$1");
            input = Regex.Replace(input, @"\[I;([^\]]+)\]", "[$1]");
            input = Regex.Replace(input, "\"minecraft", "minecraft");
            input = Regex.Replace(input, "minecraft\"", "minecraft");
            input = Regex.Replace(input, @"minecraft:[\w_]+", "\"$0\"");
            input = Regex.Replace(input, @":\s*([a-zA-Z_]+)(?=[,\}\]])", ": \"$1\"");

            return input;
        }

        public static object Deserialize(JsonElement element, Type targetType) =>
            targetType switch
            {
                Type t when t == typeof(Position) =>
                    element.ValueKind == JsonValueKind.Array
                        ? ToPosition(element.GetRawText())
                        : ToPosition(element.GetString() ?? "[]"),

                Type t when t == typeof(Rotation) =>
                    element.ValueKind == JsonValueKind.Array
                        ? ToRotation(element.GetRawText())
                        : ToRotation(element.GetString() ?? "[]"),

                Type t when t == typeof(Motion) =>
                    element.ValueKind == JsonValueKind.Array
                        ? ToMotion(element.GetRawText())
                        : ToMotion(element.GetString() ?? "[]"),

                Type t when t == typeof(List<ItemStack>) => ToItemStackList(element),
                Type t when t.IsEnum => Enum.Parse(t, element.GetString() ?? "", ignoreCase: true),
                Type t when t == typeof(int) => element.GetInt32(),
                Type t when t == typeof(double) => element.GetDouble(),
                Type t when t == typeof(string) => element.GetString() ?? "",
                Type t when Nullable.GetUnderlyingType(t) is Type underlyingType =>
                    element.ValueKind == JsonValueKind.Null ? null : Deserialize(element, underlyingType),
                _ => throw new NotSupportedException($"DeserializeValue: 型 {targetType} は未対応です")
            };

        public static Position ToPosition(string value)
        {
            var arr = ParseDoubleArray(value, 3);
            return new Position(arr[0], arr[1], arr[2]);
        }

        public static Rotation ToRotation(string value)
        {
            var arr = ParseDoubleArray(value, 2);
            return new Rotation(arr[0], arr[1]);
        }

        public static Motion ToMotion(string value)
        {
            var arr = ParseDoubleArray(value, 3);
            return new Motion(arr[0], arr[1], arr[2]);
        }

        public static string ToString(string value)
        {
            return value ?? "";
        }

        public static int ToInt(string value)
        {
            return int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        public static double ToDouble(string value)
        {
            return double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        }

        public static List<ItemStack> ToItemStackList(JsonElement itemsProp)
        {
            var items = new List<ItemStack>();
            foreach (var item in itemsProp.EnumerateArray())
            {
                var slot = item.TryGetProperty("Slot", out var s) ? s.GetInt32() : 0;
                var id = item.TryGetProperty("id", out var i) ? i.GetString() ?? "" : "";
                var count = item.TryGetProperty("count", out var c) ? c.GetInt32() : 0;

                items.Add(new ItemStack((ushort)slot, id, (ushort)count));
            }
            return items;
        }

        private static double[] ParseDoubleArray(string value, int minLength)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new double[minLength];

            value = value.Trim('[', ']').Replace("d", "").Replace("f", "");
            var parts = value.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var arr = new double[minLength];

            for (int i = 0; i < minLength && i < parts.Length; i++)
            {
                double.TryParse(parts[i], NumberStyles.Any, CultureInfo.InvariantCulture, out arr[i]);
            }
            return arr;
        }
    }
}
