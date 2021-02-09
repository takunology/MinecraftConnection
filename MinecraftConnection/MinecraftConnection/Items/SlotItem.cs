using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Items
{
    public class SlotItem
    {
        public int ItemSlot { get; set; }
        public string ItemID { get; set; }
        public int ItemCount { get; set; }

        public SlotItem(int ItemSlot, string ItemID, int ItemCount)
        {
            this.ItemSlot = ItemSlot;
            this.ItemID = ItemID;
            this.ItemCount = ItemCount;
        }
    }
}
