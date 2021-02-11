using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Items
{
    public class MinecraftColors
    {
        public int Color { get; set; }

        public MinecraftColors(byte Red, byte Green, byte Blue)
        {
            Color = Red * Green * Blue;
        }
    }
}
