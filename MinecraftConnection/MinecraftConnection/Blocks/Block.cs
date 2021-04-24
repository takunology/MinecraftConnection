using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Blocks
{
    public class Block : BlockBase
    {
        public string BlockID { get; set; }
        public BlockBase BlockStates { get; set; }

        public Block(string BlockID)
        {
            this.BlockID = BlockID;
        }
    }
}
