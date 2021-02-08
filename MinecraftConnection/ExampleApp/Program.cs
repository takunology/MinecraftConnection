using System;
using System.Net;
using CoreRCON;
using System.Collections.Generic;

using MinecraftConnection;
using MinecraftConnection.Items;
using MinecraftConnection.FireworkItems;
using MinecraftConnection.Data;
using CoreRCON.Parsers.Standard;

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
            items.Add(new Item("minecraft:diamond", 4, 0));
            items.Add(new Item("minecraft:chest", 2, 5));
            items.Add(new Item("minecraft:oak_planks", 8, 1)); 
            items.Add(new Item("minecraft:oak_planks", 16, 8));
            items.Add(new Item("minecraft:stone", 9, 3));
            items.Add(new Item("minecraft:stone", 46, 10));
            items.Add(new Item("minecraft:torch", 42, 11));
            items.Add(new Item("minecraft:stone", 55, 12));
            items.Add(new Item("minecraft:torch", 23, 16));
            items.Add(new Item("minecraft:stone", 1, 7));

            ChestItems chestItems = new ChestItems(rcon);
            var getItems = chestItems.GetChestItems(244, 74, 2866);

            Console.WriteLine("取得したチェストアイテム");
            foreach (var item in getItems)
            {
                Console.WriteLine($"{item.GetItemSlot()} {item.GetItemID()} {item.GetItemCount()}");
            }

            /*Console.WriteLine("\nソートしたチェストアイテム");
            var sortedItems = chestItems.SortByItemCount(getItems);
            foreach (var item in sortedItems)
            {
                Console.WriteLine($"{item.GetItemSlot()} {item.GetItemID()} {item.GetItemCount()}");
            }*/

            //chestItems.SetChestItems(244, 74, 2866, sortedItems);
        }
    }
}
