using MinecraftConnection.Tools;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MinecraftConnection.Entities
{
    public class Entity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Health { get; set; }
        public int? Hunger { get; set; }
        public Position Position { get; set; }
        public Motion Motion { get; set; }
        public Rotation Rotation { get; set; }
        public List<ItemStack> Items { get; set; } = [];
        public Dictionary<string, object> AdditionalData { get; set; } = new();
    }

    public static class EntityInfoParser
    {
        public static Entity Parse(string rawData)
        {
            var info = new Entity();
            var dict = new Dictionary<string, object>();

            var regex = new Regex(@"(\w+):\s*(\[[^\]]*\]|\S+)", RegexOptions.Compiled);
            foreach (Match match in regex.Matches(rawData))
            {
                var key = match.Groups[1].Value;
                var value = match.Groups[2].Value;

                switch (key)
                {
                    case "Health":
                        if (int.TryParse(value.TrimEnd('f'), NumberStyles.Any, CultureInfo.InvariantCulture, out var h))
                            info.Health = h;
                        break;
                    case "Pos":
                        info.Position = NbtDeserializer.DeserializePosition(value);
                        break;
                    case "Rotation":
                        info.Rotation = NbtDeserializer.DeserializeRotation(value);
                        break;
                    case "Motion":
                        info.Motion = NbtDeserializer.DeserializeMotion(value);
                        break;
                    case "Inventory":
                    case "Items":
                        info.Items.Clear();
                        info.Items.AddRange(NbtDeserializer.DeserializeItems(value));
                        break;
                    default:
                        dict[key] = value;
                        break;
                }
            }

            info.AdditionalData.Clear();
            foreach (var kv in dict) info.AdditionalData[kv.Key] = kv.Value;

            return info;
        }
    }

}
