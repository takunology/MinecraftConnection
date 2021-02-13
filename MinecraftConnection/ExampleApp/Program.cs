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
            /*var PlayerData = Command.GetPlayerData(PlayerName);
            int x = PlayerData.PositionX;
            int y = PlayerData.PositionY;
            int z = PlayerData.PositionZ;*/

            var Enchant = new Dictionary<Enchantments, int>();
            Enchant.Add(Enchantments.AquaAffinity, 1);
            Enchant.Add(Enchantments.FireProtection, 2);
            Enchant.Add(Enchantments.FeatherFalling, 1);
            Enchant.Add(Enchantments.Fortune, 3);

            EnchantedBook enchantedBook = new EnchantedBook(Enchant);
            Command.GiveEnchantedBook(PlayerName, enchantedBook, 1);
        }
    }
}
