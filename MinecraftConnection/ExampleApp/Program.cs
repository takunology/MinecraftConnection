using System;
using System.Net;
using CoreRCON;
using System.Collections.Generic;

using MinecraftConnection;
using MinecraftConnection.Items;
using MinecraftConnection.Data;
using MinecraftConnection.NBT;

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
            int x = PlayerData.PositionX + 30;
            int y = PlayerData.PositionY - 10;
            int z = PlayerData.PositionZ;

            List<FireworksColors> color_1 = new List<FireworksColors>() { FireworksColors.CYAN };
            List<FireworksColors> color_2 = new List<FireworksColors>() { FireworksColors.BLUE };
            Fireworks fireworks = new Fireworks(0, 2, FireworksShapes.Burst, false, true, color_1, color_2);

            while (true)
            {
                for (int i = 0; i < 10; i++)
                {
                    command.SetOffFireworks(x, y + i * 2, z, fireworks.Motion(0.0, 1.0, 3.0));
                    command.SetOffFireworks(x, y + i * 2, z, fireworks.Motion(0.0, -1.0, -3.0));
                    command.SetOffFireworks(x, y + i * 2, z, fireworks.Motion(0.0, -1.0, 3.0));
                    command.SetOffFireworks(x, y + i * 2, z, fireworks.Motion(0.0, 1.0, -3.0));
                    command.Wait(200);
                }
            }
        }
    }
}