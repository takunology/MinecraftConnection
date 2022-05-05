using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MinecraftConnection.RCON;
using MinecraftConnection.Entity;
using MinecraftConnection.Extends;
using MinecraftConnection.Block;

namespace MinecraftConnection
{
    public partial class MinecraftCommands
    {
        public MinecraftCommands(string address, ushort port, string password)
        {
            PublicRcon.Address = address;
            PublicRcon.Port = port;
            PublicRcon.Password = password;
            PublicRcon.Rcon = new MinecraftRCON(address, port, password);
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
            return PublicRcon.Rcon.SendCommand(command);
        }

        public string TimeSet(ushort time) => PublicRcon.Rcon.SendCommand($"time set {time}");

        public void Wait(ushort time) => Thread.Sleep(time);

        public Player GetPlayerData(string playerName) => new Player(playerName);

        public string DisplayTitle(string title)
        {
            return PublicRcon.Rcon.SendCommand($"title @a title \"{title}\"");
        }

        public string SetSubTitle(string subTitle)
        {
            return PublicRcon.Rcon.SendCommand($"title @a subtitle \"{subTitle}\"");
        }

        public string SetOffFireworks(Position position, Fireworks fireworks)
        {
            return PublicRcon.Rcon.SendCommand($"summon firework_rocket {position.X} {position.Y} {position.Z} {fireworks.GetNBT()}");
        }

        public string SetOffFireworks(int x, int y, int z, Fireworks fireworks)
        {
            return PublicRcon.Rcon.SendCommand($"summon firework_rocket {x} {y} {z} {fireworks.GetNBT()}");
        }

        public string SetBlock(int x, int y, int z, string blockId)
        {
            return PublicRcon.Rcon.SendCommand($"setblock {x} {y} {z} {blockId}");
        }

        public string SetBlock(Position position, BlockItem block)
        {
            return PublicRcon.Rcon.SendCommand($"setblock {position.X} {position.Y} {position.Z} {block.BlockId}");
        }
    }
}
