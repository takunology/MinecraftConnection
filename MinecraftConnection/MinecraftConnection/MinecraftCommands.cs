using System.Collections.Generic;
using System.Threading.Tasks;
using MinecraftConnection.RCON;

namespace MinecraftConnection
{
    public partial class MinecraftCommands
    {
        private readonly MinecraftRCON _rcon;

        public MinecraftCommands(string address, ushort port, string password)
        {
            _rcon = new MinecraftRCON(address, port, password);
        }
    }
    /// <summary>
    /// Standard Minecraft commands set.
    /// </summary>
    public partial class MinecraftCommands
    {
        public string SendCommand(string command)
        {
            if (command.Equals("stop"))
                throw new System.Exception("The stop command can only be sent from the server console.");
            return _rcon.SendCommand(command);
        }

        public string TimeSet(ushort time)
        {
            return _rcon.SendCommand($"time set {time}");
        }

    }
}
