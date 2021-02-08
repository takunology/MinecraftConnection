using MinecraftConnection.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Items
{
    public class Item
    {
        private string ItemID { get; set; } = "minecraft:air";
        private int ItemCount { get; set; } = 0;
        private int ItemSlot { get; set; } = -1;
        private Directions Direction { get; set; }
        //private HarfBlocks IsHarf { get; set; } //そのアイテムはハーフブロックか
        private ItemTypes ItemYype { get; set; } 
        //private ItemDirections ItemDirection { get; set; }

        /// <summary>
        /// マインクラフトで使用するアイテムを登録します。
        /// </summary>
        /// <param name="ItemID">アイテム名(ID)</param>
        /// <param name="ItemCount">アイテム数</param>
        /// <param name="ItemSlot">アイテムスロット</param>
        public Item(string ItemID, int ItemCount, int ItemSlot)
        {
            this.ItemID = ItemID;
            this.ItemCount = ItemCount;
            this.ItemSlot = ItemSlot;
        }

        /// <summary>
        /// アイテム名 (ID) を取得します。
        /// </summary>
        /// <returns>string ItemID</returns>
        public string GetItemID()
        {
            return this.ItemID;
        }
        /// <summary>
        /// アイテム数を取得します。
        /// </summary>
        /// <returns>int ItemCount</returns>
        public int GetItemCount()
        {
            return this.ItemCount;
        }
        /// <summary>
        /// アイテムスロットを取得します。
        /// </summary>
        /// <returns>int ItemSlot</returns>
        public int GetItemSlot()
        {
            return this.ItemSlot;
        }
    }
}
