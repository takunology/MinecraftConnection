using CoreRCON;
using MinecraftConnection.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MinecraftConnection.Data
{
    public class ChestItemsBase
    {
        protected RCON rcon { get; set; }
        protected List<Item> ChestItemsList = new List<Item>();
        protected List<string> ChestItemsNBTList = new List<string>();

        /// <summary>
        /// チェスト内のアイテムを取得します。
        /// </summary>
        /// <param name="x">チェストのx座標</param>
        /// <param name="y">チェストのy座標</param>
        /// <param name="z">チェストのz座標</param>
        /// <returns></returns>
        protected async Task GetChestItemsAsync(int x, int y, int z)
        {
            int ChestItemSlot = 27;
            await rcon.ConnectAsync();

            string result = await rcon.SendCommandAsync($"/data get block {x} {y} {z}");
            if (result.Contains("no")) throw new Exception("チェストが見つかりません。");

                for (int i = 0; i < ChestItemSlot; i++)
            {
                result = await rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}]");
                if (!result.Contains("no"))
                {
                    result = await rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}].Slot");
                    result = result.Substring(result.IndexOf("data"));
                    int ItemSlot = int.Parse(Regex.Replace(result, @"[^0-9]", ""));
                    
                    result = await rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}].id");
                    result = result.Substring(result.IndexOf("\""));
                    string ItemID = Regex.Replace(result, @"[^a-zA-Z:_]", "");

                    result = await rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}].Count");
                    result = result.Substring(result.IndexOf("data"));
                    int ItemCount = int.Parse(Regex.Replace(result, @"[^0-9]", ""));

                    ChestItemsList.Add(new Item(ItemID, ItemCount, ItemSlot));
                }
            }
        }
        /// <summary>
        /// チェスト内のアイテムを書き換えます。
        /// </summary>
        /// <param name="x">チェストのx座標</param>
        /// <param name="y">チェストのy座標</param>
        /// <param name="z">チェストのz座標</param>
        /// <param name="ItemList">書きかえるアイテム（リスト）</param>
        /// <returns></returns>
        protected async Task SetChestItemsAsync(int x, int y, int z, List<Item> ItemList)
        {
            string result = await rcon.SendCommandAsync($"/data get block {x} {y} {z}");
            if (result.Contains("no")) throw new Exception("チェストがみつかりません");
            
            string NBT = "";
            // storage -> append -> merge to chest -> remove
            await rcon.ConnectAsync();
            await rcon.SendCommandAsync("/data merge storage chestitems {Items:[]}");

            ChestItemsNBT(ItemList);

            foreach(var item in ChestItemsNBTList)
            {
                NBT = "{" + item + "}";
                await rcon.SendCommandAsync($"/data modify storage chestitems Items append value {NBT}");
                await rcon.SendCommandAsync($"/data modify block {x} {y} {z} Items set from storage chestitems Items");
            }
            await rcon.SendCommandAsync($"/data remove storage chestitems Items");
        }


        private void ChestItemsNBT(List<Item> ItemList)
        {
            foreach (var item in ItemList)
            {
                ChestItemsNBTList.Add($"Slot:{item.GetItemSlot()}b,id:\"{item.GetItemID()}\",Count:{item.GetItemCount()}b");
            }
        }
    }
}
