using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MinecraftConnection.Items;

namespace MinecraftConnection.NBT
{
    public static class SlotItemsNBT
    {
        /// <summary>
        /// スロットアイテムのリストをNBTタグに変換します。
        /// </summary>
        /// <param name="SlotItemList">スロットアイテムのリスト</param>
        /// <returns></returns>
        public static List<string> ToNBT(this List<SlotItem> SlotItemList)
        {
            List<string> SlotItemsNBT = new List<string>();
            foreach(var item in SlotItemList)
            {
                SlotItemsNBT.Add("{" + $"Slot:{item.ItemSlot}b,id:\"{item.ItemID}\",Count:{item.ItemCount}b" + "}");
            }
            return SlotItemsNBT;
        }
        /// <summary>
        /// NBTをスロットアイテムのリストに変換します。
        /// </summary>
        /// <param name="NBT">NBTの文字列</param>
        /// <returns></returns>
        /*public static List<SlotItem> ToSlotItemList(this string NBT)
        {
            if (!NBT.Contains("{"))
                throw new Exception("NBT形式ではないため変換できません。");
            if (!NBT.Contains("Slot"))
                throw new Exception("NBT タグに Slot 要素がないため変換できません。");

            List<SlotItem> SlotItemList = new List<SlotItem>();

            return SlotItemList;
        }*/
    }
}
