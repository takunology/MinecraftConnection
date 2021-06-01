using System;
using System.Net;
using CoreRCON;
using System.Collections.Generic;

using MinecraftConnection;
using MinecraftConnection.Blocks;
using MinecraftConnection.Items;
using MinecraftConnection.Data;

namespace ExampleApp
{
    class Program
    {
        private static IPAddress Address = IPAddress.Parse("127.0.0.1");
        private static ushort Port = 25575;
        private static string Pass = "minecraft";
        private static MinecraftCommands command = new MinecraftCommands(Address, Port, Pass);

        static void Main(string[] args)
        {
            string PlayerName = "takunology";
            var PlayerData = command.GetPlayerData(PlayerName);
            int x = PlayerData.PositionX;
            int y = PlayerData.PositionY;
            int z = PlayerData.PositionZ;
           
        }
    }
}