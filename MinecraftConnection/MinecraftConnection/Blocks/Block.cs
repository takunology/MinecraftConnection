using MinecraftConnection.Tools;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MinecraftConnection.Blocks
{
    public class Block : IBlock
    {
        public string Id { get; set; }
        public Position Position { get; set; } = new ();
        public List<ItemStack> Items { get; set; } = [];
        public Dictionary<string, JsonElement> ExtraData { get; set; } = [];
    }

    public static class BlockParser
    {
        private static string NormalizeToJson(string input)
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

            return input;
        }

        public static Block Parse(string rawData)
        {
            if (string.IsNullOrWhiteSpace(rawData))
                return new Block();

            var json = NormalizeToJson(rawData);

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            var block = new Block
            {
                Id = root.TryGetProperty("id", out var idProp) ? idProp.GetString() ?? "" : "",
                Position = new Position(
                    root.TryGetProperty("x", out var xProp) ? xProp.GetInt32() : 0,
                    root.TryGetProperty("y", out var yProp) ? yProp.GetInt32() : 0,
                    root.TryGetProperty("z", out var zProp) ? zProp.GetInt32() : 0
                )
            };

            if (root.TryGetProperty("Items", out var itemsProp) && itemsProp.ValueKind == JsonValueKind.Array)
            {
                block.Items.Clear();
                block.Items.AddRange(NbtDeserializer.DeserializeItems(itemsProp.GetRawText()));
            }

            foreach (var prop in root.EnumerateObject())
            {
                if (prop.Name is not ("id" or "x" or "y" or "z" or "Items"))
                    block.ExtraData[prop.Name] = prop.Value.Clone();
            }

            return block;
        }
    }
}
