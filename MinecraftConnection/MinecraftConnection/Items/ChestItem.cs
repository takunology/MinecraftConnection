using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoreRCON;
using MinecraftConnection.NBT;

namespace MinecraftConnection.Items
{
    /// <summary>
    /// チェストアイテムに対する操作を行うクラスです。
    /// </summary>
    public partial class ChestItem
    {
        private RCON Rcon { get; set; }
        /// <summary>
        /// チェスト内のアイテム
        /// </summary>
        public List<SlotItem> ChestItems { get; private set; }
        private int x { get; set; }
        private int y { get; set; }
        private int z { get; set; }

        public ChestItem(int x, int y, int z, RCON Rcon)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.Rcon = Rcon;
        }
        /// <summary>
        /// チェスト内のアイテムを取得します。
        /// </summary>
        /// <param name="x">チェストの座標x</param>
        /// <param name="y">チェストの座標y</param>
        /// <param name="z">チェストの座標z</param>
        public List<SlotItem> GetChestItems()
        {
            Task.Run(async () => { await GetChestItemsAsync(); }).GetAwaiter().GetResult();
            return ChestItems;
        }
        /// <summary>
        /// チェスト内のアイテムを書き換えます。
        /// </summary>
        /// <param name="x">チェストの座標x</param>
        /// <param name="y">チェストの座標y</param>
        /// <param name="z">チェストの座標z</param>
        /// <param name="SlotItemList">スロットアイテムのリスト</param>
        public void SetChestItems(List<SlotItem> SlotItemList)
        {
            Task.Run(async () => { await SetChestItemsAsync(SlotItemList); }).GetAwaiter().GetResult();
        }
    }

    public partial class ChestItem
    {
        private async Task GetChestItemsAsync()
        {
            await Rcon.ConnectAsync();
            string result = await Rcon.SendCommandAsync($"/data get block {x} {y} {z}");

            if (result.Contains("no")) throw new Exception("チェストが見つかりません。");

            int ChestItemSlot = 27;
            ChestItems = new List<SlotItem>();

            for (int i = 0; i < ChestItemSlot; i++)
            {
                result = await Rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}]");
                if (!result.Contains("no"))
                {
                    result = await Rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}].Slot");
                    result = result.Substring(result.IndexOf("data"));
                    int ItemSlot = int.Parse(Regex.Replace(result, @"[^0-9]", ""));

                    result = await Rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}].id");
                    result = result.Substring(result.IndexOf("\""));
                    string ItemID = Regex.Replace(result, @"[^a-zA-Z:_]", "");

                    result = await Rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}].Count");
                    result = result.Substring(result.IndexOf("data"));
                    int ItemCount = int.Parse(Regex.Replace(result, @"[^0-9]", ""));

                    ChestItems.Add(new SlotItem(ItemSlot, ItemID, ItemCount));
                }
            }
        }
        private async Task SetChestItemsAsync(List<SlotItem> SlotItemList)
        {
            string result = await Rcon.SendCommandAsync($"/data get block {x} {y} {z}");
            if (result.Contains("no")) throw new Exception("チェストが見つかりません。");

            // storage -> append -> merge to chest -> remove
            await Rcon.ConnectAsync();
            await Rcon.SendCommandAsync("/data merge storage chestitems {Items:[]}");

            foreach (var item in SlotItemList.ToNBT())
            {
                await Rcon.SendCommandAsync($"/data modify storage chestitems Items append value {item}");
                await Rcon.SendCommandAsync($"/data modify block {x} {y} {z} Items set from storage chestitems Items");
            }
            await Rcon.SendCommandAsync($"/data remove storage chestitems Items");
        }
    }
}
