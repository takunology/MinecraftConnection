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
        private static readonly IPAddress _address = IPAddress.Parse("127.0.0.1");
        private static readonly ushort _port = 25575;
        private static readonly string _pass = "minecraft";
        private static MinecraftCommands command = new MinecraftCommands(_address, _port, _pass);

        static void Main(string[] args)
        {
            string playerName = "takunology";

            var playerData = command.GetPlayerData(playerName);
            int x = playerData.PositionX + 30;
            int y = playerData.PositionY - 10;
            int z = playerData.PositionZ;

            List<FireworksColors> excolor = new List<FireworksColors>() { FireworksColors.BLUE };
            List<FireworksColors> fadecolor = new List<FireworksColors>() { FireworksColors.CYAN };

            Fireworks fireworks = new Fireworks(0, 2, FireworksShapes.Burst, false, true, excolor, fadecolor);

            for(int i = 0; i < 10; i++)
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