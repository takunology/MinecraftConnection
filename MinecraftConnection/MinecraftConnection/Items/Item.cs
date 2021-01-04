using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Items
{
    public class Item
    {
        private string ItemID { get; set; }
        private bool IsDirection { get; set; } //そのアイテムは方向に依存するか
        //private HarfBlocks IsHarf { get; set; } //そのアイテムはハーフブロックか
        private ItemTypes ItemYype { get; set; } 
        //private ItemDirections ItemDirection { get; set; }
    }
}
