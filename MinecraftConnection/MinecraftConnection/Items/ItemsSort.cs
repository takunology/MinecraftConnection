using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MinecraftConnection.Items;

namespace MinecraftConnection.Items
{
    public static class ItemsSort
    {
        /// <summary>
        /// アイテムをできるだけ1つにまとめます。
        /// </summary>
        /// <param name="SlotItemList">スロットアイテムのリスト</param>
        /// <returns></returns>
        public static List<SlotItem> CollectItems(this List<SlotItem> SlotItemList)
        {
            List<SlotItem> SortedItemList = new List<SlotItem>();
            SortedItemList = SortByID(SlotItemList);
            var DuplicationItems = SortedItemList.Select(x => x.ItemID).Distinct();
            // 1スタック = 64個 でまとめる
            Dictionary<string, int> CountSumItems = new Dictionary<string, int>();

            foreach (var item in DuplicationItems)
            {
                CountSumItems.Add(item, 0);
            }

            for (int i = 0; i < SlotItemList.Count; i++)
            {
                foreach (var item in DuplicationItems)
                {
                    if (item == SlotItemList[i].ItemID)
                    {
                        CountSumItems[item] += SlotItemList[i].ItemCount;
                    }
                }
            }

            SortedItemList = new List<SlotItem>();
            int SlotIndex = 0; //スロットIDを振りなおす
            foreach (var item in CountSumItems)
            {
                if (item.Value <= 64)
                {
                    SortedItemList.Add(new SlotItem(SlotIndex, item.Key, item.Value));
                    SlotIndex++;
                }
                else if (item.Value > 64)
                {
                    //雪玉などのアイテム数上限が変化するものはどうするか課題
                    int stack = item.Value / 64;
                    int over = item.Value % 64;
                    for (int i = 0; i < stack; i++)
                    {
                        SortedItemList.Add(new SlotItem(SlotIndex, item.Key, 64));
                        SlotIndex++;
                    }
                    SortedItemList.Add(new SlotItem(SlotIndex, item.Key, over));
                    SlotIndex++;
                }
            }
#if DEBUG
            Console.WriteLine("\nItemSLOT \t\t ItemID \t\t ItemCOUNT");
            foreach (var item in SlotItemList)
            {
                Console.WriteLine($"{item.ItemSlot} \t\t {item.ItemID} \t\t {item.ItemCount}");
            }
#endif
            return SortedItemList;
        }
        /// <summary>
        /// アイテム名（ID）をキーとして昇順に並べ替えます。
        /// </summary>
        /// <param name="SlotItemList">スロットアイテムのリスト</param>
        /// <returns></returns>
        public static List<SlotItem> SortByID(this List<SlotItem> SlotItemList)
        {
            List<SlotItem> SortedItemList = new List<SlotItem>();
            SortedItemList = SlotItemList
                            .OrderBy(x => x.ItemID)
                            .ThenBy(x => x.ItemCount)
                            .ToList();
            return SlotNumbering(SortedItemList);
        }
        /// <summary>
        /// アイテム名（ID）をキーとして降順に並べ替えます。
        /// </summary>
        /// <param name="SlotItemList">スロットアイテムのリスト</param>
        /// <returns></returns>
        public static List<SlotItem> SortReverseByID(this List<SlotItem> SlotItemList)
        {
            List<SlotItem> SortedItemList = new List<SlotItem>();
            SortedItemList = SlotItemList
                            .OrderByDescending(x => x.ItemID)
                            .ThenBy(x => x.ItemCount)
                            .ToList();
            return SlotNumbering(SortedItemList);
        }
        /// <summary>
        /// アイテム数の多い順に並べ替えます。
        /// </summary>
        /// <param name="SlotItemList">スロットアイテムのリスト</param>
        /// <returns></returns>
        public static List<SlotItem> SortByCount(this List<SlotItem> SlotItemList)
        {
            List<SlotItem> SortedItemList = new List<SlotItem>();
            SortedItemList = SlotItemList
                            .OrderByDescending(x => x.ItemCount)
                            .ToList();
            return SlotNumbering(SortedItemList);
        }
        /// <summary>
        /// アイテム数の少ない順に並べ替えます。
        /// </summary>
        /// <param name="SlotItemList">スロットアイテムのリスト</param>
        /// <returns></returns>
        public static List<SlotItem> SortReverseByCount(this List<SlotItem> SlotItemList)
        {
            List<SlotItem> SortedItemList = new List<SlotItem>();
            SortedItemList = SlotItemList
                            .OrderBy(x => x.ItemCount)
                            .ToList();
            return SlotNumbering(SortedItemList);
        }
        //同名のアイテムを横一列に並べ替える
        //同名のアイテムを縦一列に並べ替える  ->　横、縦の数を超える場合はなるべく揃えるようにする

        private static List<SlotItem> SlotNumbering(List<SlotItem> SlotItemList)
        {
            List<SlotItem> Items = new List<SlotItem>();
            for(int i = 0; i < SlotItemList.Count; i++)
            {
                Items.Add(new SlotItem(i, SlotItemList[i].ItemID, SlotItemList[i].ItemCount));
            }
#if DEBUG
            Console.WriteLine("\nItemSLOT \t\t ItemID \t\t ItemCOUNT");
            foreach (var item in Items)
            {
                Console.WriteLine($"{item.ItemSlot} \t\t {item.ItemID} \t\t {item.ItemCount}");
            }
#endif
            return Items;
        }
    }
}