using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using MinecraftConnection.Block.Base;
using MinecraftConnection.Extends;

namespace MinecraftConnection.Block
{
    public class ChestBlock : BlockBase
    {
        public ChestBlock(int x, int y, int z)
        {
            this.Position = new Position(x, y, z);
        }

        public ChestBlock(Position position)
        {
            this.Position = position;
        }

        public List<ItemStack> GetItems()
        {
            List<ItemStack> items = new List<ItemStack>();

            string result = PublicRcon.Rcon.SendCommand($"data get block {Position.X} {Position.Y} {Position.Z}");
            if (!result.Contains("no"))
            {
                result = PublicRcon.Rcon.SendCommand($"data get block {Position.X} {Position.Y} {Position.Z} Items");
                for (int i = 0; i < 27; i++)
                {
                    result = PublicRcon.Rcon.SendCommand($"data get block {Position.X} {Position.Y} {Position.Z} Items[{i}]");
                    if (!result.Contains("no"))
                    {
                        result = PublicRcon.Rcon.SendCommand($"/data get block {Position.X} {Position.Y} {Position.Z} Items[{i}].Slot");
                        result = result.Substring(result.IndexOf("data"));
                        ushort ItemSlot = ushort.Parse(Regex.Replace(result, @"[^0-9]", ""));

                        result = PublicRcon.Rcon.SendCommand($"/data get block {Position.X} {Position.Y} {Position.Z} Items[{i}].id");
                        result = result.Substring(result.IndexOf("\""));
                        string ItemID = Regex.Replace(result, @"[^a-zA-Z:_]", "");

                        result = PublicRcon.Rcon.SendCommand($"/data get block {Position.X} {Position.Y} {Position.Z} Items[{i}].Count");
                        result = result.Substring(result.IndexOf("data"));
                        ushort ItemCount = ushort.Parse(Regex.Replace(result, @"[^0-9]", ""));

                        items.Add(new ItemStack(ItemSlot, ItemID, ItemCount));
                    }
                }

            }
            else
            {
                throw new Exception("Chest is not found.");
            }

            return items;
        }

        public void SetItems(List<ItemStack> items)
        {
            string result = PublicRcon.Rcon.SendCommand($"data get block {Position.X} {Position.Y} {Position.Z}");
            if (!result.Contains("no"))
            {
                PublicRcon.Rcon.SendCommand("data merge storage chestitems {Items:[]}");
                PublicRcon.Rcon.SendCommand($"data modify block {Position.X} {Position.Y} {Position.Z} Items set from storage chestitems Items");
                foreach (var item in items)
                {
                    PublicRcon.Rcon.SendCommand($"data modify storage chestitems Items append value {GetNBT(item)}");
                    PublicRcon.Rcon.SendCommand($"data modify block {Position.X} {Position.Y} {Position.Z} Items set from storage chestitems Items");
                }
            }
            else
            {
                throw new Exception("Chest is not found.");
            }
        }

        private class ChestItemsNBT
        {
            [JsonPropertyName("Slot")]
            public ushort _Slot { get; set; }
            [JsonPropertyName("id")]
            public string _Id { get; set; }
            [JsonPropertyName("Count")]
            public ushort _Count { get; set; }
        }

        private string GetNBT(ItemStack item)
        {
            ChestItemsNBT nbt = new ChestItemsNBT()
            {
                _Id = item.Id,
                _Slot = item.Slot,
                _Count = item.Count,
            };
            return JsonSerializer.Serialize(nbt);
        }
    }
}
