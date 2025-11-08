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
            //AsyncTest();
            //CommandTest();
            FireworksTest();
        }

        static async Task AsyncTest() 
        {
            var command = new MinecraftCommand(address, port, pass);

            var result = await command.SayAsync("hello");
            Console.WriteLine("Say test => " + result);

            result = await command.TimeSetAsync(Time.Noon);
            Console.WriteLine("TimeSet test => " + result);

            result = await command.TpAsync(-14, 63, -17);
            Console.WriteLine("Tp test => " + result);

            result = await command.SummonAsync("cow", -14, 63, -17);
            Console.WriteLine("Summon test => " + result);

            var fw = new FireworkRocket
            {
                Colors = FireworkOption.GetRandomColors(),
                LifeTime = 20
            };
            result = await command.SummonAsync(fw, -14, 63, -17);
            Console.WriteLine("Summon test => " + result);

            result = await command.SubTitleAsync("from C#");
            Console.WriteLine("Title test => " + result);

            result = await command.TitleAsync("Minecraft");
            Console.WriteLine("Title test => " + result);

            result = await command.SetBlockAsync(-14, 65, -17, "stone");
            Console.WriteLine("Setblock test => " + result);

            result = await command.FillAsync(-14, 65, -17, -14, 67, -17, "air");
            Console.WriteLine("Fill test => " + result);

            result = await command.EffectAsync("@s", "speed", 5, 1);
            Console.WriteLine("Effect test => " + result);

            result = await command.GiveAsync("@s", "stone", 1);
            Console.WriteLine("Give test => " + result);

            result = await command.ClearAsync("@s", "stone", 1);
            Console.WriteLine("Give test => " + result);

            var player = await command.DataGetEntityAsync<Player>("takunology");
            Console.WriteLine("Data get test => " + player.GetNbt());

            var villager = await command.DataGetEntityAsync<Villager>("36938e2e-54f6-4e89-b007-d85cac9993a1");
            Console.WriteLine("Data get test => " + villager.GetNbt() + "\n");

            var cow = await command.DataGetEntityAsync<Villager>("0f0ece86-0c2d-4597-a8eb-b5f3df3a512b");
            Console.WriteLine("Data get test => " + cow.GetNbt() + "\n");

            result = await command.DataModifyEntityAsync("36938e2e-54f6-4e89-b007-d85cac9993a1", "Motion", new Motion(0, 0.5, 0));
            Console.WriteLine("Data modify test => " + result);

            var block = await command.DataGetBlockAsync(-14, 63, -19);
            Console.WriteLine("Data get block test => " + block.Items.Count);

            var items = new List<ItemStack>
            {
                new ItemStack(0, "minecraft:stone", 64),
                new ItemStack(1, "minecraft:diamond_sword", 1)
            };
            result = await command.DataModifyBlockAsync(-14, 63, -21, "Items", items);
            Console.WriteLine("Data modify block test => " + result);

        }

        static void CommandTest()
        {
            var command = new MinecraftCommand(address, port, pass);

            var result = command.Say("hello");
            Console.WriteLine("Say test => " + result);

            result = command.TimeSet(Time.Noon);
            Console.WriteLine("TimeSet test => " + result);

            result = command.Tp(-14, 63, -17);
            Console.WriteLine("Tp test => " + result);

            result = command.Summon("cow", -14, 63, -17);
            Console.WriteLine("Summon test => " + result);

            var fw = new FireworkRocket
            {
                Colors = FireworkOption.GetRandomColors(),
                LifeTime = 20
            };
            result = command.Summon(fw, -14, 63, -17);
            Console.WriteLine("Summon test => " + result);

            /*result = command.SubTitle("fromC#");
            Console.WriteLine("Title test => " + result);

            result = command.Title("Minecraft");
            Console.WriteLine("Title test => " + result);

            result = command.SetBlock(-14, 65, -17, "stone");
            Console.WriteLine("Setblock test => " + result);

            result = command.Fill(-14, 65, -17, -14, 67, -17, "air");
            Console.WriteLine("Fill test => " + result);

            result = command.Effect("takunology", "speed", 5, 1);
            Console.WriteLine("Effect test => " + result);

            result = command.Give("takunology", "stone", 1);
            Console.WriteLine("Give test => " + result);

            result = command.Clear("takunology", "stone", 1);
            Console.WriteLine("Clear test => " + result);

            var player = command.DataGetEntity<Player>("takunology");
            Console.WriteLine("Data get test => " + player.GetNbt());

            var villager = command.DataGetEntity<Villager>("36938e2e-54f6-4e89-b007-d85cac9993a1");
            Console.WriteLine("Data get test => " + villager.GetNbt() + "\n");

            var cow = command.DataGetEntity<GeneralEntity>("0f0ece86-0c2d-4597-a8eb-b5f3df3a512b");
            Console.WriteLine("Data get test => " + cow.GetNbt() + "\n");

            result = command.DataModifyEntity("36938e2e-54f6-4e89-b007-d85cac9993a1", "Motion", new Motion(0, 0.5, 0));
            Console.WriteLine("Data modify test => " + result);

            var block = command.DataGetBlock(-14, 63, -19);
            Console.WriteLine("Data get block test => " + block.Items.Count);

            var items = new List<ItemStack>
            {
                new ItemStack(0, "minecraft:stone", 64),
                new ItemStack(1, "minecraft:diamond_sword", 1)
            };
            result = command.DataModifyBlock(-14, 63, -21, "Items", items);
            Console.WriteLine("Data modify block test => " + result);*/

        }

        static void FireworksTest()
        {
            using var command = new MinecraftCommand(address, port, pass);
            var fw = new FireworkRocket
            {
                LifeTime = 30,
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