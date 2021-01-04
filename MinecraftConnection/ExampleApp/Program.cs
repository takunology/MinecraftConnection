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
            
            foreach (var item in InventoryItems)
            {              
                Console.WriteLine($"{item.GetItemSlot()} {item.GetItemID()} {item.GetItemCount()}");
            }

            
            Firework MyFirework = new Firework(30, 2, FireworksShapes.LargeBall, true, false, FireworksColors.CYAN, FireworksColors.GREEN);
            //command.SetOffFireworks(x, y, z + 20, MyFirework);

            //Console.WriteLine(result);
        }
    }
}
