using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MinecraftConnection.RCON;
using MinecraftConnection.Entity;
using MinecraftConnection.Extends;

namespace MinecraftConnection
{
    public partial class MinecraftCommands
    {
        private MinecraftRCON _rcon;

        public MinecraftCommands(string address, ushort port, string password)
        {
            PublicRcon.Address = address;
            PublicRcon.Port = port;
            PublicRcon.Password = password;
            this._rcon = new MinecraftRCON(address, port, password);
            PublicRcon.Rcon = this._rcon;
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

        public string TimeSet(ushort time) => _rcon.SendCommand($"time set {time}");

        public void Wait(ushort time) => Thread.Sleep(time);

        public PlayerEntity GetPlayerData(string playerName) => new PlayerEntity(playerName);

        public string DisplayTitle(string title)
        {
            return _rcon.SendCommand($"title @a title \"{title}\"");
        }

        public string SetSubTitle(string subTitle)
        {
            return _rcon.SendCommand($"title @a subtitle \"{subTitle}\"");
        }

        public string SetOffFireworks(Position position, FireworkEntity fireworks)
        {
            return _rcon.SendCommand($"summon firework_rocket {position.X} {position.Y} {position.Z} {fireworks.GetNBT()}");
        }

        public string SetOffFireworks(int x, int y, int z, FireworkEntity fireworks)
        {
            return _rcon.SendCommand($"summon firework_rocket {x} {y} {z} {fireworks.GetNBT()}");
        }
    }
}
