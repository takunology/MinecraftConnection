using MinecraftConnection.FireworkItems;
using System;
using System.Collections.Generic;

namespace ExampleFireworksApp
{
    public class Program : MyFirewoks
    {
        //static List fireworklist = new List();
        
        static void Main(string[] args)
        {
            string PlayerName = "takunology";

            int x = data.GetPosX(PlayerName);
            int y = data.GetPosY(PlayerName) + 10;
            int z = data.GetPosZ(PlayerName) + 50;

            Random rnd = new Random();
            
            ExampleFirework_01(x, y, z);
            command.Wait(3000);
            //ExampleFirework_02(x, y, z);
            //command.Wait(3000);
            //ExampleFirework_01Main(x, y, z);

            while (true)
            {
                foreach (var item in FireworksList.LeargeBallList)
                {
                    command.SetOffFireworks(x + rnd.Next(-30, 30), y + rnd.Next(-5, 5), z, item);
                    command.Wait(50);
                }
            }
        }

        static void ExampleFirework_01Main(int x, int y, int z)
        {
            for (int i = 0; i < 20; i++)
            {
                ExampleFirework_03(x - 100 + 10 * i, y, z);
                command.Wait(100);
            }
            command.Wait(2000);
            for (int i = 0; i < 20; i++)
            {
                ExampleFirework_03(x + 100 - 10 * i, y, z);
                command.Wait(100);
            }
        }


    }
}
