using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MinecraftConnection.NBT;
using MinecraftConnection.RCON;

namespace MinecraftConnection.Items
{
    /// <summary>
    /// チェストアイテムに対する操作を行うクラスです。
    /// </summary>
    public partial class ChestItem
    {
        private readonly MinecraftRCON rcon;
        private int x;
        private int y;
        private int z;

        public ChestItem(int x, int y, int z, MinecraftRCON rcon)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.rcon = rcon;
        }
    }

    public partial class ChestItem
    {
        public List<SlotItem> GetChestItems()
        {
            string result = rcon.SendCommand($"data get block {x} {y} {z}");

            if (result.Contains("no")) throw new Exception("チェストが見つかりません。");

            int ChestItemSlot = 27;
            List<SlotItem> ChestItems = new List<SlotItem>();

            for (int i = 0; i < ChestItemSlot; i++)
            {
                result = rcon.SendCommand($"data get block {x} {y} {z} Items[{i}]");
                if (!result.Contains("no"))
                {
                    result = rcon.SendCommand($"/data get block {x} {y} {z} Items[{i}].Slot");
                    result = result.Substring(result.IndexOf("data"));
                    int ItemSlot = int.Parse(Regex.Replace(result, @"[^0-9]", ""));

                    result = rcon.SendCommand($"/data get block {x} {y} {z} Items[{i}].id");
                    result = result.Substring(result.IndexOf("\""));
                    string ItemID = Regex.Replace(result, @"[^a-zA-Z:_]", "");

                    result = rcon.SendCommand($"/data get block {x} {y} {z} Items[{i}].Count");
                    result = result.Substring(result.IndexOf("data"));
                    int ItemCount = int.Parse(Regex.Replace(result, @"[^0-9]", ""));

                    ChestItems.Add(new SlotItem(ItemSlot, ItemID, ItemCount));
                }
            }
            return ChestItems;
        }

        public void SetChestItems(List<SlotItem> SlotItemList)
        {
            string result = rcon.SendCommand($"data get block {x} {y} {z}");
            if (result.Contains("no")) throw new Exception("チェストが見つかりません。");

            // storage -> append -> merge to chest -> remove
            rcon.SendCommand("data merge storage chestitems {Items:[]}");

            foreach (var item in SlotItemList.ToNBT())
            {
                rcon.SendCommand($"data modify storage chestitems Items append value {item}");
                rcon.SendCommand($"data modify block {x} {y} {z} Items set from storage chestitems Items");
            }
            rcon.SendCommand($"data remove storage chestitems Items");
        }
    }
}
