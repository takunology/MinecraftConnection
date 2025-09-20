using MinecraftConnection;
using MinecraftConnection.Entities;
using MinecraftConnection.Tools;
using System.Text.Json;

namespace TestApp
{
    internal class Program
    {
        static string address = "127.0.0.1";
        static int port = 25575;
        static string pass = "minecraft";

        static void Main(string[] args)
        {
            using var command = new MinecraftCommand(address, port, pass);
            //var block = command.DataGetBlock(-14, 63, -19);
            //var block2 = command.DataGetBlock(-14, 63, -21);
            var items = new List<ItemStack>
            {
                new ItemStack(0, "minecraft:stone", 64),
                new ItemStack(1, "minecraft:diamond_sword", 1)
            };

            var nbt = NbtSerializer.Serialize(items);
            Console.WriteLine(nbt);
            //block.Items.ForEach(i => Console.WriteLine($"{i.Id}"));
            //command.DataModifyBlock(-14, 63, -21, "Items", items);

            var fw = new FireworkRocket
            {
                LifeTime = 50,
                Colors = FireworkOption.GetRandomColors(),
                //FadeColors = FireworkOption.GetRandomColors(),
                Shape = FireworkShape.LargeBall,
                FlightDuration = 2
            };

            fw.Colors = FireworkOption.GetRandomColors();
            //Console.WriteLine(fw.GetNbt());
            
            //command.Summon(fw, -14, 64, -19);
            
            //JsonTest();
        }

        static void JsonTest()
        {
            
        }


    }
}