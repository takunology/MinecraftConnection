using MinecraftConnection.Block.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Block
{
    public class BlockItem : BlockBase
    {
        public BlockItem(string BlockId)
        {
            this.BlockId = BlockId;
        }
    }
}