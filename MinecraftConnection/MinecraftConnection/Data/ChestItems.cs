using MinecraftConnection.Items;
using System;
using System.Collections.Generic;
using System.Text;
using CoreRCON;
using System.Threading.Tasks;

namespace MinecraftConnection.Data
{
    public class ChestItems : ChestItemsBase
    {
        public ChestItems(RCON rcon)
        {
            this.rcon = rcon;
        }
        /// <summary>
        /// チェスト内のアイテムを取得します。
        /// </summary>
        /// <param name="x">チェストのx座標</param>
        /// <param name="y">チェストのy座標</param>
        /// <param name="z">チェストのz座標</param>
        /// <returns></returns>
        public List<Item> GetChestItems(int x, int y, int z)
        {
            Task.Run(async () => { await GetChestItemsAsync(x, y, z); }).GetAwaiter().GetResult();
            return ChestItemsList;
        }
        /// <summary>
        /// チェスト内のアイテムを書き換えます。
        /// </summary>
        /// <param name="x">チェストのx座標</param>
        /// <param name="y">チェストのy座標</param>
        /// <param name="z">チェストのz座標</param>
        /// <param name="ItemList">書きかえるアイテム（リスト）</param>
        public void SetChestItems(int x, int y, int z, List<Item> ItemList)
        {
            Task.Run(async () => { await SetChestItemsAsync(x, y, z, ItemList); }).GetAwaiter().GetResult();
        }


    }
}
