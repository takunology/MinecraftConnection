using MinecraftConnection.Blocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MinecraftConnection.Tools
{
    public static class BlockParser
    {
        

        public static Block Parse(string nbt)
        {
            if (string.IsNullOrWhiteSpace(nbt))
                return new Block();

            var json = NbtDeserializer.NormalizeToJson(nbt);

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
                block.Items.AddRange(NbtDeserializer.ToItemStackList(itemsProp));
            }

            return block;
        }
    }
}
