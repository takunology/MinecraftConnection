using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Block.Base
{
    public class FurnaceBlockBase
    {
        public short BurnTime { get; set; }
        public short CookTime { get; set; }
        public short CookTimeTotal { get; set; } = 200;
    }
}
