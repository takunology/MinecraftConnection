using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Items
{
    public class MinecraftColors
    {
        public static int Black { get; set; } = 1973019;
        public static int BLUE { get; set; } = 2437522;
        public static int BROWN { get; set; } = 5320730;
        public static int CYAN { get; set; } = 2651799;
        public static int GRAY { get; set; } = 4408131;
        public static int GREEN { get; set; } = 3887386;
        public static int LIGHTBLUE { get; set; } = 6719955;
        public static int LIGHTGRAY { get; set; } = 11250603;
        public static int LIME { get; set; } = 4312372;
        public static int MAGENTA { get; set; } = 12801229;
        public static int ORANGE { get; set; } = 15435844;
        public static int PINK { get; set; } = 14188952;
        public static int PURPLE { get; set; } = 8073150;
        public static int RED { get; set; } = 11743532;
        public static int WHITE { get; set; } = 15790320;
        public static int YELLOW { get; set; } = 14602026;

        public static int CustomColor(byte Red, byte Green, byte Blue)
        {
            return Red * Green * Blue;
        }
    }
}
