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
        private int X { get; set; }
        private int Y { get; set; }
        private int Z { get; set; }

        /// <summary>
        /// チェストアイテムを操作するためのインスタンスを作ります。
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="Rcon"></param>
        public ChestItem(int X, int Y, int Z, RCON Rcon)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.Rcon = Rcon;
        }
    }

    public partial class ChestItem
    {
        /// <summary>
        /// チェスト内のアイテムを取得します。
        /// </summary>
        public async Task<List<SlotItem>> GetChestItemsAsync()
        {
            await Rcon.ConnectAsync();
            string result = await Rcon.SendCommandAsync($"/data get block {X} {Y} {Z}");

            if (result.Contains("no")) throw new Exception("チェストが見つかりません。");

            int ChestItemSlot = 27;
            List<SlotItem> ChestItems = new List<SlotItem>();

            for (int i = 0; i < ChestItemSlot; i++)
            {
                result = await Rcon.SendCommandAsync($"/data get block {X} {Y} {Z} Items[{i}]");
                if (!result.Contains("no"))
                {
                    result = await Rcon.SendCommandAsync($"/data get block {X} {Y} {Z} Items[{i}].Slot");
                    result = result.Substring(result.IndexOf("data"));
                    int ItemSlot = int.Parse(Regex.Replace(result, @"[^0-9]", ""));

                    result = await Rcon.SendCommandAsync($"/data get block {X} {Y} {Z} Items[{i}].id");
                    result = result.Substring(result.IndexOf("\""));
                    string ItemID = Regex.Replace(result, @"[^a-zA-Z:_]", "");

                    result = await Rcon.SendCommandAsync($"/data get block {X} {Y} {Z} Items[{i}].Count");
                    result = result.Substring(result.IndexOf("data"));
                    int ItemCount = int.Parse(Regex.Replace(result, @"[^0-9]", ""));

                    ChestItems.Add(new SlotItem(ItemSlot, ItemID, ItemCount));
                }
            }
            return ChestItems;
        }
        /// <summary>
        /// チェスト内のアイテムを書き換えます。
        /// </summary>
        /// <param name="x">チェストの座標x</param>
        /// <param name="y">チェストの座標y</param>
        /// <param name="z">チェストの座標z</param>
        /// <param name="SlotItemList">スロットアイテムのリスト</param>
        public async Task SetChestItemsAsync(List<SlotItem> SlotItemList)
        {
            string result = await Rcon.SendCommandAsync($"/data get block {X} {Y} {Z}");
            if (result.Contains("no")) throw new Exception("チェストが見つかりません。");

            // storage -> append -> merge to chest -> remove
            await Rcon.ConnectAsync();
            await Rcon.SendCommandAsync("/data merge storage chestitems {Items:[]}");

            foreach (var item in SlotItemList.ToNBT())
            {
                await Rcon.SendCommandAsync($"/data modify storage chestitems Items append value {item}");
                await Rcon.SendCommandAsync($"/data modify block {X} {Y} {Z} Items set from storage chestitems Items");
            }
            await Rcon.SendCommandAsync($"/data remove storage chestitems Items");
        }
    }
}
