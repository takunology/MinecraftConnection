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

        static void Main(string[] args)
        {
            Commands command = new Commands(rcon);
            PlayerData data = new PlayerData(rcon);

            string PlayerName = "takunology";

            List<Item> InventoryItems = data.GetInventoryItems(PlayerName);
            var HandItems = data.GetHandItems(PlayerName);
            var EquipmentItems = data.GetEquipmentItems(PlayerName);
            var LeftHandItem = data.GetLeftHandItem(PlayerName);
            var FoodLevel = data.GetFoodLevel("");
            
            Console.WriteLine("=== インベントリスロットアイテム ===");
            foreach (var item in InventoryItems)
            {
                Console.WriteLine($"{item.GetItemSlot()} 番目のアイテムは {item.GetItemID()} で {item.GetItemCount()} 個所持しています。");
            }

            Console.WriteLine("=== 手持ちスロットアイテム ===");
            foreach (var item in HandItems)
            {
                Console.WriteLine($"{item.GetItemSlot()} 番目のアイテムは {item.GetItemID()} で {item.GetItemCount()} 個所持しています。");
            }

            Console.WriteLine("=== 装備アイテム ===");
            foreach (var item in EquipmentItems)
            {
                Console.WriteLine($"{item.GetItemSlot()} 番目のアイテムは {item.GetItemID()} で {item.GetItemCount()} 個所持しています。");
            }

            Console.WriteLine("=== 左手のアイテム ===");
            Console.WriteLine($"{LeftHandItem.GetItemSlot()} 番目のアイテムは {LeftHandItem.GetItemID()} で {LeftHandItem.GetItemCount()} 個所持しています。");

            Console.WriteLine($"満腹度は {FoodLevel}");
        }
    }
}