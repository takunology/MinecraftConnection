using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using CoreRCON;

namespace MinecraftConnection
{
    public class RconSettings
    {
        protected RCON Rcon { get; private set; }

        protected void RconSet(IPAddress IpAddress, ushort Port, string PassWord)
        { 
            Rcon = new RCON(IpAddress, Port, PassWord);
        }
    }
}
