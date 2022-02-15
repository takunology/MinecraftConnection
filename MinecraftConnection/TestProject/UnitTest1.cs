using MinecraftConnection;
using MinecraftConnection.Items;
using MinecraftConnection.NBT;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{ 
    [TestClass]
    public class Sample
    {
        static string address = "127.0.0.1";
        static ushort port = 25575;
        static string pass = "minecraft";
        static MinecraftCommands commands = new MinecraftCommands(address, port, pass);

        //[TestMethod]
        public void CommandTest()
        {
            int x = -961 + 20;
            int y = 70;
            int z = -798;

            var rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                Fireworks fireworks = new Fireworks(20, FireworksShapes.LargeBall, FireworksOptions.RandomColors(0, 5), FireworksOptions.RandomColors(0, 5)).Trail();
                Console.WriteLine(fireworks.ToNBT());
                commands.SetOffFireworks(x + rnd.Next(0, 20), y + rnd.Next(-5, 10), z + rnd.Next(-30, 30), fireworks);
                commands.Wait(100);
            }     
        }

        [TestMethod]
        public void GetPos()
        {
            var playerData = commands.GetPlayerData("takunology");
            Console.WriteLine($"{playerData.PositionX} {playerData.PositionY} {playerData.PositionZ}");
        }

        //[TestMethod]
        public void FireworksTest()
        {
            // Azure用の座標
            /*int x = -52 - 40;
            int y = 68;
            int z = 92;*/

            // Local用の座標
            int x = -961 + 20;
            int y = 70;
            int z = -798;

            /*while (true)
            {
                Kiku(x, y, z, 30);
                commands.Wait(2000);
            }*/
            Kiku(x, y, z, 30);

        }

        public void Kiku(int x, int y, int z, int time)
        {
            Fireworks fireworksIn = new Fireworks(time, FireworksShapes.SmallBall, FireworksColors.RED, FireworksColors.RED).Trail();
            Fireworks fireworksOut = new Fireworks(time, FireworksShapes.LargeBall, FireworksColors.ORANGE, FireworksColors.ORANGE).Trail();
            commands.SetOffFireworks(x, y, z, fireworksOut);
            commands.SetOffFireworks(x, y, z, fireworksIn);
            commands.Wait(1000);

            fireworksIn = new Fireworks(time, FireworksShapes.SmallBall, FireworksColors.GREEN, FireworksColors.GREEN).Trail();
            fireworksOut = new Fireworks(time, FireworksShapes.LargeBall, FireworksColors.LIME, FireworksColors.LIME).Trail();
            commands.SetOffFireworks(x, y, z + 14, fireworksOut);
            commands.SetOffFireworks(x, y, z + 14, fireworksIn);
            commands.Wait(1000);

            fireworksIn = new Fireworks(time, FireworksShapes.SmallBall, FireworksColors.BLUE, FireworksColors.BLUE);
            fireworksOut = new Fireworks(time, FireworksShapes.LargeBall, FireworksColors.LIGHTBLUE, FireworksColors.LIGHTBLUE);
            commands.SetOffFireworks(x, y, z + 28, fireworksOut);
            commands.SetOffFireworks(x, y, z + 28, fireworksIn);
        }
    }

}