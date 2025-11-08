using MinecraftConnection.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MinecraftConnection.Tools
{
    public static class NbtSerializer
    {
        public static string Serialize(object? obj)
        {
            return obj switch
            {
                null => "null",
                int i => i.ToString(),
                bool b => b ? "1" : "0",
                string s => $"\"{s}\"",
                Enum e => ToSnakeCase(e),
                Motion m => ToMotionArray(m),
                Position p => ToPositionArray(p),
                Rotation r => ToRotationArray(r),
                NbtIntArray arr => "[I;" + string.Join(",", arr.Values) + "]",
                Dictionary<string, object?> dict =>
                    "{" + string.Join(",", dict.Select(kv => $"{kv.Key}:{Serialize(kv.Value)}")) + "}",
                ItemStack item => Serialize(item.ToNbt()),
                IEnumerable e => "[" + string.Join(",", e.Cast<object>().Select(Serialize)) + "]",
                _ => throw new NotSupportedException($"Type {obj.GetType()} not supported in NbtSerializer")
            };
        }

        public static string ToSnakeCase(Enum value) 
            => string.Concat(value.ToString().Select((c, i) =>
            i > 0 && char.IsUpper(c) ? "_" + char.ToLower(c) : char.ToLower(c).ToString()));

        public static string ToColorArrayString(List<FireworkColor> colors) 
            => "[I;" + string.Join(",", colors.Select(c => (int)c)) + "]";

        public static NbtIntArray ToColorArray(List<FireworkColor> colors)
            => new(colors.Select(c => (int)c).ToList());

        public static int BoolToInt(bool value) => value ? 1 : 0;

        private static string ToMotionArray(Motion m)
            => $"[{m.X}d,{m.Y}d,{m.Z}d]";

        private static string ToPositionArray(Position p)
            => $"[{p.X}d,{p.Y}d,{p.Z}d]";

        private static string ToRotationArray(Rotation r)
            => $"[{r.X}f,{r.Y}f]";
    }

    public class NbtIntArray
    {
        public List<int> Values { get; }
        public NbtIntArray(List<int> values) => Values = values;
    }
}
