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

            Console.WriteLine($"体力 : {data.GetHealth(PlayerName)}");
            Console.WriteLine($"満腹度 : {data.GetFoodLevel(PlayerName)}");
            Console.WriteLine($"スコア : {data.GetScore(PlayerName)}");
        }
    }
}