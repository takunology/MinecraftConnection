using System;
using System.Net;
using CoreRCON;
using System.Collections.Generic;

using MinecraftConnection;
using MinecraftConnection.Items;
using MinecraftConnection.FireworkItems;
using MinecraftConnection.Data;

namespace ExampleApp
{
    class Program
    {
        private static IPAddress IP = IPAddress.Parse("127.0.0.1");
        private static ushort Port = 25575;
        private static string Password = "minecraft";
        private static RCON rcon = new RCON(IP, Port, Password);
        private static MinecraftCommands command = new MinecraftCommands(rcon);

        static void Main(string[] args)
        {
            //string PlayerName = "takunology";

            var items = new List<Item>();
            items.Add(new Item("minecraft:diamond", 64, 0));
            items.Add(new Item("minecraft:chest", 2, 5));
            items.Add(new Item("minecraft:oak_planks", 8, 1));
            items.Add(new Item("minecraft:stone", 32, 3));

            ChestItems chestItems = new ChestItems(rcon);
            chestItems.SetChestItems(244, 74, 2866, items);
        }
    }
}