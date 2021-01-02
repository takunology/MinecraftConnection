using System;
using MinecraftConnection;
using MinecraftConnection.Items;
using MinecraftConnection.FireworkItems;
using System.Collections.Generic;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MCConnection connection = new MCConnection("127.0.0.1", 25575, "minecraft");

            int locateX = 794;
            int locateY = 68;
            int locateZ = 1407 + 30;
            //string result = connection.SendCommand("/time set 0");
            //string result = connection.SetBlock(340, 67, 668, BlockItems.AcaciaLeaves);
            //string result = connection.DisplayTitle(3.1415);
            //string result = connection.DisplayMessage("Hello");
            //string result = connection.GiveItem("takunology", BlockItems.Diorite, 3);
            //string result = connection.GiveEffect("takunology", "poison", 3);
            //string result = connection.Summon(Entity.Blaze, 100, 100, 100);

            Random rnd = new Random();
            //connection.SetOffFireworks(locateX + rnd.Next(-30, 30), locateY + rnd.Next(-5, 10), locateZ + rnd.Next(-5, 5), Fireworks.CreeperRed);


            for (int i = 0; i < 10; i++)
            {
                foreach(var item in FireworksList.BurstList)
                {
                    connection.SetOffFireworks(locateX + rnd.Next(-30, 30), locateY + rnd.Next(-5, 10), locateZ + rnd.Next(-5, 5), item);
                    connection.Wait(100);
                }

                Console.WriteLine($"打ち上げ{i}回目");
            }

            for (int i = 0; i < 10; i++)
            {
                foreach (var item in FireworksList.BurstTrailList)
                {
                    connection.SetOffFireworks(locateX + rnd.Next(-30, 30), locateY + rnd.Next(-5, 10), locateZ + rnd.Next(-5, 5), item);
                    connection.Wait(100);
                }

                Console.WriteLine($"打ち上げ{i}回目");
            }

            for (int i = 0; i < 10; i++)
            {
                foreach (var item in FireworksList.BurstFlickerList)
                {
                    connection.SetOffFireworks(locateX + rnd.Next(-30, 30), locateY + rnd.Next(-5, 10), locateZ + rnd.Next(-5, 5), item);
                    connection.Wait(100);
                }

                Console.WriteLine($"打ち上げ{i}回目");
            }

            for (int i = 0; i < 10; i++)
            {
                foreach (var item in FireworksList.BurstFlickerTrailList)
                {
                    connection.SetOffFireworks(locateX + rnd.Next(-30, 30), locateY + rnd.Next(-5, 10), locateZ + rnd.Next(-5, 5), item);
                    connection.Wait(100);
                }

                Console.WriteLine($"打ち上げ{i}回目");
            }

            //Console.WriteLine(result);
        }
    }
}
