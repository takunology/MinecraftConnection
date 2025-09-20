using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MinecraftConnection.Tools
{
    public static class NbtDeserializer
    {
        public static Position DeserializePosition(string value)
        {
            var arr = ParseDoubleArray(value, 3);
            return new Position(arr[0], arr[1], arr[2]);
        }

        public static Rotation DeserializeRotation(string value)
        {
            var arr = ParseDoubleArray(value, 2);
            return new Rotation(arr[0], arr[1]);
        }

        public static Motion DeserializeMotion(string value)
        {
            var arr = ParseDoubleArray(value, 3);
            return new Motion(arr[0], arr[1], arr[2]);
        }

        public static List<ItemStack> DeserializeItems(string value)
        {
            var items = new List<ItemStack>();
            var regex = new Regex(@"\{Slot:(\d+)b,id:""([^""]+)"",count:(\d+)b\}");
            foreach (Match m in regex.Matches(value))
            {
                var slot = int.Parse(m.Groups[1].Value);
                var id = m.Groups[2].Value;
                var count = int.Parse(m.Groups[3].Value);
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
