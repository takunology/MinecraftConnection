using MinecraftConnection.RCON;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Extends
{
    public static class PublicRcon
    {
        public static string Address { get; set; }
        public static ushort Port { get; set; }
        public static string Password { get; set; }
        public static MinecraftRCON Rcon { get; set; }
    }
}
