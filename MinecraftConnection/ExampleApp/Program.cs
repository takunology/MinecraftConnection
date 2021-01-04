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

            int locateX = 794;
            int locateY = 68;
            int locateZ = 1407 + 20;

            Firework MyFirework = new Firework(30, 2, FireworksShapes.LargeBall, true, false, FireworksColors.CYAN, FireworksColors.GREEN);
            //command.SetOffFireworks(locateX, locateY, locateZ, MyFirework);

            //Console.WriteLine(result);
        }
    }
}
