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
        /// アイテム名（ID）をキーとして昇順に並べ替えます。
        /// </summary>
        /// <param name="SlotItemList">スロットアイテムのリスト</param>
        /// <returns></returns>
        public static List<SlotItem> SortByID(this List<SlotItem> SlotItemList)
        {
            List<SlotItem> SortedItemList = new List<SlotItem>();
            SortedItemList = SlotItemList
                            .OrderBy(x => x.ItemID)
                            .ThenBy(x => x.ItemSlot)
                            .ThenBy(x => x.ItemCount)
                            .ToList();
            return SortedItemList;
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
                            .ThenBy(x => x.ItemSlot)
                            .ThenBy(x => x.ItemCount)
                            .ToList();
            return SortedItemList;
        }
    }
}