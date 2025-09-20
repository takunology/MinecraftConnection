using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftConnection.Tools
{
    public static class NbtSerializer
    {
        public static string Serialize(object value)
        {
            return value switch
            {
                ItemStack item => SerializeItem(item),
                List<ItemStack> items => SerializeItems(items),
                Position pos => SerializeVector(pos.X, pos.Y, pos.Z),
                Motion mot => SerializeVector(mot.X, mot.Y, mot.Z),
                Rotation rot => SerializeVector(rot.X, rot.Y),
                IEnumerable<object> list => $"[{string.Join(",", list.Select(Serialize))}]",
                string s => $"\"{s}\"",
                int or float or double => value.ToString(),
                _ => throw new NotSupportedException($"Unsupported type: {value.GetType().Name}"),
            };
        }

        public static T Deserialize<T>(string nbt)
        {
            throw new NotImplementedException();
        }

        private static string SerializeItem(ItemStack item)
        {
            return $"{{Slot:{item.Slot}b,id:\"{item.Id}\",count:{item.Count}b}}";
        }

        private static string SerializeItems(List<ItemStack> items)
        {
            var itemStrings = items.Select(item =>
                $"{{Slot:{item.Slot}b,id:\"{item.Id}\",count:{item.Count}b}}"
            );
            return $"[{string.Join(",", itemStrings)}]";
        }

        private static string SerializeVector(params double[] values)
        {
            return $"[{string.Join(",", values)}]";
        }
    }
}
