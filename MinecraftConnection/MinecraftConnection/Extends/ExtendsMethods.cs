using MinecraftConnection.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MinecraftConnection.Extends
{
    public static class ExtendsMethods
    {
        public static List<ItemStack> SortById(this List<ItemStack> items)
        {
            var sortedItems = items.OrderBy(x => x.Id).ToList();
            return ItemStackNumbering(ref sortedItems);
        }

        public static List<ItemStack> SortByIdDescending(this List<ItemStack> items)
        {
            var sortedItems = items.OrderByDescending(x => x.Id).ToList();
            return ItemStackNumbering(ref sortedItems);
        }

        public static List<ItemStack> SortByCount(this List<ItemStack> items)
        {
            var sortedItems = items.OrderBy(x => x.Count).ToList();
            return ItemStackNumbering(ref sortedItems);
        }

        public static List<ItemStack> SortByCountDescending(this List<ItemStack> items)
        {
            var sortedItems = items.OrderBy(x => x.Count).ToList();
            return ItemStackNumbering(ref sortedItems);
        }

        public static List<ItemStack> SortItems(this List<ItemStack> items)
        {
            var groupingItems = items.OrderBy(x => x.Id).GroupBy(x => x.Id);
            var itemsDic = new Dictionary<string, int>();
            var sortedItems = new List<ItemStack>();
            var count = 0;

            foreach(var group in groupingItems)
            {
                foreach (var item in group)
                {
                    count += item.Count;
                }
                itemsDic.Add(group.Key, count);
            }

            ushort slotNum = 0;
            foreach (var item in itemsDic)
            {
                if (item.Value / 64 > 0)
                {
                    for (int i = 0; i < item.Value / 64; i++)
                    {
                        sortedItems.Add(new ItemStack(slotNum, item.Key, 64));
                        slotNum++;
                    }

                    if (item.Value % 64 == 0)
                    {
                        continue;
                    }

                    sortedItems.Add(new ItemStack(slotNum, item.Key, (ushort)(item.Value % 64)));
                    slotNum++;
                }
                else
                {
                    sortedItems.Add(new ItemStack(slotNum, item.Key, (ushort)(item.Value % 64)));
                    slotNum++;
                }
            }


            // アイテムスタック 16 個の場合はどうするか
            return sortedItems;
        }

        private static List<ItemStack> ItemStackNumbering(ref List<ItemStack> items)
        {
            List<ItemStack> numberingItems = new List<ItemStack>();
            for(ushort i = 0; i < items.Count; i++)
            {
                numberingItems.Add(new ItemStack(i, items[i].Id, items[i].Count));
            }
            return numberingItems;
        }
        
    }
}
