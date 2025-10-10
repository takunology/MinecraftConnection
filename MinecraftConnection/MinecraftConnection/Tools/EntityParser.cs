using MinecraftConnection.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.Json;

namespace MinecraftConnection.Tools
{
    public static class EntityParser
    {
        public static Entity Parse(string nbt)
        {
            var json = NbtDeserializer.NormalizeToJson(nbt);
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            int playerGameType = 99;
            string profession = "";

            if (root.TryGetProperty("playerGameType", out var gameTypeElement))
            {
                if (int.TryParse(gameTypeElement.ToString(), out var value))
                    playerGameType = value;
            }

            if (root.TryGetProperty("VillagerData", out var villagerData) &&
                villagerData.TryGetProperty("profession", out var profElement))
            {
                profession = profElement.GetString() ?? "";
            }

            if (playerGameType != 99)
            {
                return ParsePlayer(root, nbt);
            }
            else if (!string.IsNullOrEmpty(profession))
            {
                return ParseVillager(root, nbt);
            }

            return ParseGeneric(root, "", nbt);
        }

        private static Player ParsePlayer(JsonElement root, string rawNbt)
        {
            var pos = (Position)NbtDeserializer.Deserialize(root.GetProperty("Pos"), typeof(Position));
            var motion = (Motion)NbtDeserializer.Deserialize(root.GetProperty("Motion"), typeof(Motion));
            var health = root.TryGetProperty("Health", out var h) ? h.GetDouble() : 20;
            var name = root.TryGetProperty("CustomName", out var n) ? n.GetString() ?? "" : "";

            var inventory = root.TryGetProperty("Inventory", out var inv)
                ? (List<ItemStack>)NbtDeserializer.Deserialize(inv, typeof(List<ItemStack>))
                : new List<ItemStack>();

            return new Player 
            { 
                Position = pos, 
                Motion = motion, 
                Health = health, 
                Name = name, 
                Inventory = inventory,
                Nbt = rawNbt
            };
        }

        private static Villager ParseVillager(JsonElement root, string rawNbt)
        {
            var pos = (Position)NbtDeserializer.Deserialize(root.GetProperty("Pos"), typeof(Position));
            var motion = (Motion)NbtDeserializer.Deserialize(root.GetProperty("Motion"), typeof(Motion));
            var profession = root.TryGetProperty("Profession", out var p) ? p.GetString() ?? "" : "";
            var level = root.TryGetProperty("VillagerData", out var vd) && vd.TryGetProperty("level", out var lv)
                ? lv.GetInt32()
                : 1;
            var isBaby = root.TryGetProperty("IsBaby", out var b) && b.GetInt32() == 1;

            return new Villager 
            { 
                Position = pos, 
                Motion = motion, 
                Profession = profession, 
                Level = level, 
                IsBaby = isBaby, 
                Nbt = rawNbt
            };
        }

        private static Entity ParseGeneric(JsonElement root, string id, string rawNbt)
        {
            var pos = (Position)NbtDeserializer.Deserialize(root.GetProperty("Pos"), typeof(Position));
            var motion = (Motion)NbtDeserializer.Deserialize(root.GetProperty("Motion"), typeof(Motion));
            var entity = new GeneralEntity(id);
            entity.Position = pos;
            entity.Motion = motion;
            entity.Nbt = rawNbt;
            
            return entity;

        }
    }

}
