using System;
using System.Net;
using CoreRCON;
using System.Collections.Generic;

using MinecraftConnection;
using MinecraftConnection.Items;
using MinecraftConnection.NBT;

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
            int x = PlayerData.PositionX;
            int y = PlayerData.PositionY;
            int z = PlayerData.PositionZ;

            var Items = Command.GetChestItems(244, 74, 2866);
           
            foreach(var item in Items.ToNBT())
            {
                Console.WriteLine(item);
            }

            Command.SetChestItems(244, 74, 2868, Items.CollectItems());
        }
    }
}