using MinecraftConnection.Block;
using MinecraftConnection.Entity;
using MinecraftConnection.Extends;
using MinecraftConnection.RCON;
using System.Collections.Generic;
using System.Threading;

namespace MinecraftConnection
{
    /// <summary>
    /// Create an instance to send commands to Minecraft.
    /// </summary>
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
        /// <summary>
        /// Execute any command.
        /// </summary>
        /// <param name="command">Minecraft command</param>
        /// <returns>Result of command execution</returns>
        /// <exception cref="System.Exception">The stop command cannot be executed from a remote console.</exception>
        public string SendCommand(string command)
        {
            if (command.Equals("stop"))
                throw new System.Exception("The stop command can only be sent from the server console.");
            return PublicRcon.Rcon.SendCommand(command);
        }

        /// <summary>
        /// Sets the time in Minecraft.
        /// </summary>
        /// <param name="time">Any time</param>
        /// <returns>Result of command execution</returns>
        public string TimeSet(ushort time) => PublicRcon.Rcon.SendCommand($"time set {time}");

        /// <summary>
        /// Sets the time in Minecraft.
        /// </summary>
        /// <param name="time">Any time</param>
        /// <returns>Result of command execution</returns>
        public string TimeSet(Time time) => PublicRcon.Rcon.SendCommand($"time set {time.GetHashCode()}");

        /// <summary>
        /// Teleports any entity to the specified coordinates.
        /// </summary>
        /// <param name="entityName">Entity ID or Player ID</param>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        /// <param name="z">Coordinate z</param>
        /// <returns></returns>
        public string Teleport(string entityName, int x, int y, int z) => PublicRcon.Rcon.SendCommand($"tp {entityName} {x} {y} {z}");

        /// <summary>
        /// Teleports any entity to the specified coordinates.
        /// </summary>
        /// <param name="entityName">Entity ID or Player ID</param>
        /// <param name="position">Coordinates to be teleport</param>
        /// <returns></returns>
        public string Teleport(string entityName, Position position) => PublicRcon.Rcon.SendCommand($"tp {entityName} {position.X} {position.Y} {position.Z}");

        /// <summary>
        /// Wait for a specified period of time.
        /// </summary>
        /// <param name="time">Any time</param>
        public void Wait(ushort time) => Thread.Sleep(time);

        /// <summary>
        /// Get entity data about the player.
        /// </summary>
        /// <param name="playerName">player ID</param>
        /// <returns>Player class</returns>
        public Player GetPlayerData(string playerName) => new Player(playerName);

        /// <summary>
        /// Display the title in the center of the game screen.
        /// </summary>
        /// <param name="title">Any string</param>
        /// <returns>Result of command execution</returns>
        public string DisplayTitle(string title)
        {
            return PublicRcon.Rcon.SendCommand($"title @a title \"{title}\"");
        }

        /// <summary>
        /// Set subtitle. The subtitle will be displayed with the title when it is displayed.
        /// </summary>
        /// <param name="subTitle">Any string</param>
        /// <returns>Result of command execution</returns>
        public string SetSubTitle(string subTitle)
        {
            return PublicRcon.Rcon.SendCommand($"title @a subtitle \"{subTitle}\"");
        }
        
        /// <summary>
        /// Send a message to minecraft.
        /// </summary>
        /// <param name="message">message</param>
        /// <returns></returns>
        public string DisplayMessage(string message)
        {
            return PublicRcon.Rcon.SendCommand($"msg @a \"{message}\"");
        }

        /// <summary>
        /// Fireworks are set off from the specified coordinates.
        /// </summary>
        /// <param name="position">Coordinates to be set off</param>
        /// <param name="fireworks">Fireworks instance</param>
        /// <returns></returns>
        public string SetOffFireworks(Position position, Fireworks fireworks)
        {
            return PublicRcon.Rcon.SendCommand($"summon firework_rocket {position.X} {position.Y} {position.Z} {fireworks.GetNBT()}");
        }

        /// <summary>
        /// Fireworks are set off from the specified coordinates.
        /// </summary>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        /// <param name="z">Coordinate z</param>
        /// <param name="fireworks">Fireworks instance</param>
        /// <returns></returns>
        public string SetOffFireworks(double x, double y, double z, Fireworks fireworks)
        {
            return PublicRcon.Rcon.SendCommand($"summon firework_rocket {(int)x} {(int)y} {(int)z} {fireworks.GetNBT()}");
        }

        /// <summary>
        /// Places the block at the specified coordinates.
        /// </summary>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        /// <param name="z">Coordinate z</param>
        /// <param name="blockId">Block ID</param>
        /// <returns></returns>
        public string SetBlock(int x, int y, int z, string blockId)
        {
            return PublicRcon.Rcon.SendCommand($"setblock {x} {y} {z} {blockId}");
        }

        /// <summary>
        /// Places the block at the specified coordinates.
        /// </summary>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        /// <param name="z">Coordinate z</param>
        /// <param name="blockId">Block ID</param>
        /// <returns></returns>
        public string SetBlock(double x, double y, double z, string blockId)
        {
            return SetBlock((int)x, (int)y, (int)z, blockId);
        }

        /// <summary>
        /// Places the block at the specified coordinates.
        /// </summary>
        /// <param name="position">Block Position</param>
        /// <param name="blockId">Block ID</param>
        /// <returns></returns>
        public string SetBlock(Position position, string blockId)
        {
            return SetBlock(position.X, position.Y, position.Z, blockId);
        }

        /// <summary>
        /// Get the items in the chest placed at the specified coordinates.
        /// </summary>
        /// <param name="position">Chest Coordinates</param>
        /// <returns>Receives item stacks in list form.</returns>
        public List<ItemStack> GetChestItems(Position position)
        {
            var chestItems = new ChestBlock(position);
            return chestItems.GetItems();
        }

        /// <summary>
        /// Get the items in the chest placed at the specified coordinates.
        /// </summary>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        /// <param name="z">Coordinate z</param>
        /// <returns>Receives item stacks in list form.</returns>
        public List<ItemStack> GetChestItems(int x, int y, int z)
        {
            var chestItems = new ChestBlock(x, y, z);
            return chestItems.GetItems();
        }

        /// <summary>
        /// Sets the items in the chest at the specified coordinates.
        /// </summary>
        /// <param name="position">Chest Coordinates</param>
        /// <param name="items">List of items to be set</param>
        public void SetChestItems(Position position, List<ItemStack> items)
        {
            var chestItems = new ChestBlock(position);
            chestItems.SetItems(items);
        }

        /// <summary>
        /// Sets the items in the chest at the specified coordinates.
        /// </summary>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        /// <param name="z">Coordinate z</param>
        /// <param name="items">List of items to be set</param>
        public void SetChestItems(int x, int y, int z, List<ItemStack> items)
        {
            var chestItems = new ChestBlock(x, y, z);
            chestItems.SetItems(items);
        }

        /// <summary>
        /// Play Minecraft sound effects.
        /// </summary>
        /// <param name="sound">Type of sound effects</param>
        public void PlaySound(Sound sound)
        {
            var playSound = new PlaySound(sound);
            SendCommand(playSound.MakeCommand());
        }

        /// <summary>
        /// Play Minecraft sound effects.
        /// </summary>
        /// <param name="sound">Type of sound effects</param>
        /// <param name="pitch">Sound height (up to 2.0)</param>
        public void PlaySound(Sound sound, double pitch)
        {
            var playSound = new PlaySound(sound);
            SendCommand(playSound.MakeCommand(pitch));
        }
    }
}
