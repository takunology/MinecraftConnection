using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Block.Base
{
    public class InventoryBlockBase
    {
        public List<ItemStack> Items { get; set; } = new List<ItemStack>();
    }
}
