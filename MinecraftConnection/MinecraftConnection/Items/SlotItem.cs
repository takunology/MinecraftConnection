using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Items
{
    /// <summary>
    /// アイテムスロットつきのアイテムを管理するクラスです。
    /// </summary>
    public class SlotItem
    {
        /// <summary>
        /// アイテムスロット
        /// </summary>
        public int ItemSlot { get; set; }
        /// <summary>
        /// アイテム名（ID）
        /// </summary>
        public string ItemID { get; set; }
        /// <summary>
        /// アイテムの個数
        /// </summary>
        public int ItemCount { get; set; }
        /// <summary>
        /// アイテムスロットつきのアイテムを登録します。
        /// </summary>
        /// <param name="ItemSlot">アイテムスロット</param>
        /// <param name="ItemID">アイテム名（ID）</param>
        /// <param name="ItemCount">アイテムの個数</param>
        public SlotItem(int ItemSlot, string ItemID, int ItemCount)
        {
            this.ItemSlot = ItemSlot;
            this.ItemID = ItemID;
            this.ItemCount = ItemCount;
        }
    }
}
