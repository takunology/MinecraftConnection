using MinecraftConnection.Items;
using System;
using System.Collections.Generic;
using System.Text;
using CoreRCON;
using System.Threading.Tasks;
using System.Linq;

namespace MinecraftConnection.Data
{
    public class ChestItems : ChestItemsBase
    {
        //LINQによる並べ替えアイテムリスト
        private List<Item> SortByItemCountList = new List<Item>();

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
        /// <summary>
        /// アイテムを昇順に並べ替えます。
        /// </summary>
        /// <param name="ItemList">アイテム（リスト）</param>
        private void ChestItemsCountSort(List<Item> ItemList)
        {
            var queryItems = ItemList
                .OrderByDescending(x => x.GetItemCount())
                .ThenBy(x => x.GetItemID())
                .ThenBy(x => x.GetItemSlot());            
            
            foreach(var item in queryItems)
            {
                Console.WriteLine($"{item.GetItemSlot()} \t {item.GetItemID()} \t {item.GetItemCount()}");
            }
            
        }
        /// <summary>
        /// アイテムを降順に並べ替えます。
        /// </summary>
        /// <param name="ItemList">アイテム（リスト）</param>
        private void ChestItemsCountSortReverse(List<Item> ItemList)
        {
            var queryItems = ItemList
                .OrderBy(x => x.GetItemCount())
                .ThenBy(x => x.GetItemID())
                .ThenBy(x => x.GetItemSlot());

            foreach (var item in queryItems)
            {
                Console.WriteLine($"{item.GetItemSlot()} \t {item.GetItemID()} \t {item.GetItemCount()}");
            }
        }

        //アイテムID順に並び替える
        public List<Item> SortByItemCount(List<Item> ItemList)
        {
            //名前順に並べ替え
            var queryItems = ItemList
                .OrderBy(x => x.GetItemID())
                .ThenBy(x => x.GetItemCount())
                .ThenBy(x => x.GetItemSlot())
                .ToList();

            //重複アイテムの抽出
            var distinctes = queryItems.Select(x => x.GetItemID()).Distinct();

            //重複したアイテムを全て合計して一つの要素にまとめる
            Dictionary<string, int> ItemsSum = new Dictionary<string, int>();
            //Dictionary初期化
            foreach (var item in distinctes)
            {
                ItemsSum.Add(item, 0);
            }

            for (int i = 0; i < ItemList.Count; i++)
            {
                foreach(var element in distinctes)
                {
                    if(element == ItemList[i].GetItemID())
                    {
                        ItemsSum[element] += ItemList[i].GetItemCount();
                    }
                }
            }

            //アイテムスロットのID
            int SlotIndex = 0;

            foreach(var item in ItemsSum)
            {
                if(item.Value <= 64)
                {
                    SortByItemCountList.Add(new Item(item.Key, item.Value, SlotIndex));
                    SlotIndex++;
                }
                else if(item.Value > 64)
                {
                    int stack = item.Value / 64;
                    int over = item.Value % 64;

                    for(int i = 0; i < stack; i++)
                    {
                        SortByItemCountList.Add(new Item(item.Key, 64, SlotIndex));
                        SlotIndex++;
                    }
                    SortByItemCountList.Add(new Item(item.Key, over, SlotIndex));
                    SlotIndex++;
                }
            }

            return SortByItemCountList;
#if DEBUG
            foreach (var item in queryItems)
            {
                Console.WriteLine($"{item.GetItemSlot()} \t {item.GetItemID()} \t {item.GetItemCount()}");
            }

            foreach (var item in ItemsSum)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

            Console.WriteLine("=== Items Sorted ===");
            foreach(var item in SortByItemCountList)
            {
                Console.WriteLine($"{item.GetItemSlot()} \t {item.GetItemID()} \t {item.GetItemCount()}");
            }
#endif
        }
    }
}
