using System;
using System.Net;
using CoreRCON;
using System.Collections.Generic;

using MinecraftConnection;

namespace ExampleApp
{
    class Program
    {
        private static IPAddress Address = IPAddress.Parse("127.0.0.1");
        private static ushort Port = 25575;
        private static string Pass = "minecraft";
        private static MinecraftCommands Command = new MinecraftCommands(Address, Port, Pass);

        static void Main(string[] args)
        {
            string PlayerName = "takunology";
            var PlayerData = Command.GetPlayerData(PlayerName);
            //Command.SendCommand("/time set 0");
            int x = PlayerData.PositionX;
            int y = PlayerData.PositionY;
            int z = PlayerData.PositionZ;

            Console.WriteLine($"{x} {y} {z}" );

            foreach(var item in PlayerData.AllItems)
            {
                Console.WriteLine($"{item.ItemSlot} {item.ItemID} {item.ItemCount}");
            }
        }
    }
}
