using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection
{
    public class MinecraftColors
    {
        public static MinecraftColors[] MCColor;
        public static MinecraftColors BLACK = register("black");
        public static MinecraftColors RED;
        public static MinecraftColors BLUE;
        public static MinecraftColors Green;

        private static MinecraftColors register(string color)
        {
            return register(color);
        }
    }
}
