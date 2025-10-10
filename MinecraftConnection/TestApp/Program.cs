using MinecraftConnection;
using MinecraftConnection.Entities;
using MinecraftConnection.Blocks;
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
            GetNbtTest();
        }

        static void FireworksTest()
        {
            using var command = new MinecraftCommand(address, port, pass);
            var fw = new FireworkRocket
            {
                LifeTime = 50,
                Colors = FireworkOption.GetRandomColors(),
                Shape = FireworkShape.LargeBall,
                FlightDuration = 2
            };

            fw.Colors = FireworkOption.GetRandomColors();
            command.Summon(fw, -14, 64, -19);
            Console.WriteLine(fw.GetNbt());
        }

        static void GetItemsTest()
        {
            using var command = new MinecraftCommand(address, port, pass);
            var block = command.DataGetBlock(-14, 63, -19);
            block.Items.ForEach(item => Console.WriteLine($"{item.Id}"));
        }

        static void GetNbtTest()
        {
            using var command = new MinecraftCommand(address, port, pass);
            
            var player = command.DataGetEntity<Player>("takunology");
            Console.WriteLine(player.GetNbt() + "\n\n");

            var villager = command.DataGetEntity<Villager>("36938e2e-54f6-4e89-b007-d85cac9993a1");
            Console.WriteLine(villager.GetNbt() + "\n\n");

            var cow = command.DataGetEntity<GeneralEntity>("0f0ece86-0c2d-4597-a8eb-b5f3df3a512b");
            Console.WriteLine(cow.GetNbt());
        }

        static void SetItemsTest()
        {
            using var command = new MinecraftCommand(address, port, pass);
            var items = new List<ItemStack>
            {
                new ItemStack(0, "minecraft:stone", 64),
                new ItemStack(1, "minecraft:diamond_sword", 1)
            };
 
            command.DataModifyBlock(-14, 63, -21, "Items", items);
        }

    }
}