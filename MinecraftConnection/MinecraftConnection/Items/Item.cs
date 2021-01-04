using MinecraftConnection.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Items
{
    public class Item
    {
        private string ItemID { get; set; }
        private int ItemCount { get; set; }
        private int ItemSlot { get; set; }
        private Directions Direction { get; set; } //そのアイテムは方向に依存するか
        //private HarfBlocks IsHarf { get; set; } //そのアイテムはハーフブロックか
        private ItemTypes ItemYype { get; set; } 
        //private ItemDirections ItemDirection { get; set; }

        public Item(string ItemID, int ItemCount, int ItemSlot)
        {
            this.ItemID = ItemID;
            this.ItemCount = ItemCount;
            this.ItemSlot = ItemSlot;
        }

        public string GetItemID()
        {
            return this.ItemID;
        }

        public int GetItemCount()
        {
            return this.ItemCount;
        }

        public int GetItemSlot()
        {
            return this.ItemSlot;
        }
    }
}
