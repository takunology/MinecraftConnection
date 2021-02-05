using System;
using System.Collections.Generic;
using System.Text;

using CoreRCON;
using MinecraftConnection;
using MinecraftConnection.Data;
using MinecraftConnection.FireworkItems;
using System.Net;

namespace ExampleFireworksApp
{
    public class MyFirewoks
    {
        private static IPAddress IP = IPAddress.Parse("127.0.0.1");
        private static ushort Port = 25575;
        private static string Password = "minecraft";
        private static RCON rcon = new RCON(IP, Port, Password);
        protected static Commands command = new Commands(rcon);
        protected static PlayerData data = new PlayerData(rcon);

        public static void ExampleFirework_01(int x, int y, int z)
        {
            Firework fireworkred = new Firework(0, 2, FireworksShapes.SmallBall, true, false, FireworksColors.RED, FireworksColors.RED);
            Firework fireworkyellow = new Firework(0, 2, FireworksShapes.SmallBall, true, false, FireworksColors.YELLOW, FireworksColors.YELLOW);
            Firework fireworkgreen = new Firework(0, 2, FireworksShapes.SmallBall, true, false, FireworksColors.GREEN, FireworksColors.GREEN);
            Firework fireworkmagenta = new Firework(0, 2, FireworksShapes.SmallBall, true, false, FireworksColors.MAGENTA, FireworksColors.MAGENTA);

            int shifty = 19;

            command.SetOffFireworks(x, y, z, Fireworks.LeargeBallCyan);
            command.Wait(2000);

            command.SetOffFireworks(x + 8, y + shifty, z, fireworkred);
            command.SetOffFireworks(x - 8, y + shifty, z, fireworkred);
            command.SetOffFireworks(x, y + 8 + shifty, z, fireworkyellow);
            command.SetOffFireworks(x, y - 8 + shifty, z, fireworkyellow);
            command.SetOffFireworks(x + 5, y + 5 + shifty, z, fireworkgreen);
            command.SetOffFireworks(x - 5, y - 5 + shifty, z, fireworkgreen);
            command.SetOffFireworks(x + 5, y - 5 + shifty, z, fireworkmagenta);
            command.SetOffFireworks(x - 5, y + 5 + shifty, z, fireworkmagenta);

            command.Wait(4000);
        }
        public static void ExampleFirework_02(int x, int y, int z)
        {
            y = y + 30;

            int Distancex = 10;
            int Distancey = 10;
            int Distancez = 10;
            
            command.SetOffFireworks(x, y, z, Fireworks.LeargeBallPURPLE);

            command.SetOffFireworks(x + Distancex, y, z, Fireworks.LeargeBallPURPLE);
            command.SetOffFireworks(x - Distancex, y, z, Fireworks.LeargeBallPURPLE);

            command.SetOffFireworks(x, y + Distancey, z, Fireworks.LeargeBallPURPLE);
            command.SetOffFireworks(x, y - Distancey, z, Fireworks.LeargeBallPURPLE);

            command.SetOffFireworks(x + Distancex - 5, y + Distancey - 5, z, Fireworks.LeargeBallPURPLE);
            command.SetOffFireworks(x + Distancex - 5, y - Distancey + 5, z, Fireworks.LeargeBallPURPLE);

            command.SetOffFireworks(x - Distancex + 5, y + Distancey - 5, z, Fireworks.LeargeBallPURPLE);
            command.SetOffFireworks(x - Distancex + 5, y - Distancey + 5, z, Fireworks.LeargeBallPURPLE);
        }
        public static void ExampleFirework_03(int x, int y, int z)
        {
            y = y + 10;

            command.SetOffFireworks(x, y, z, Fireworks.LeargeBallLime);
            command.SetOffFireworks(x, y, z, Fireworks.SmallBallRed);
        }

    }
}
