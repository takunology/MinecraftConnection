using System;
using MinecraftConnection;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MCConnection connection = new MCConnection("127.0.0.1", 25575, "minecraft");

            //string result = connection.SendCommand("/time set 0");
            //string result = connection.SetBlock(340, 67, 668, BlockItems.Andesite);
            //string result = connection.DisplayTitle(3.1415);
            //string result = connection.DisplayMessage("Hello");
            //string result = connection.GiveItem("takunology", BlockItems.Diorite, 3);
            //string result = connection.GiveEffect("takunology", "poison", 3);
            string result = connection.Summon(Entity.Blaze, 100, 100, 100);

            Console.WriteLine(result);

        }
    }
}
