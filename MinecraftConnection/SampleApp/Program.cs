using MinecraftConnection;

namespace SampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var commands = new MinecraftCommands("127.0.0.1", 25575, "minecraft");
            var chestPos = new Position(-449, 63, 58);
            ItemStack item = new ItemStack(0, "diamond", 4);

            while (true)
            {
                Random rand = new Random();
                var myItem = new List<ItemStack>
                {
                    new ItemStack((ushort)rand.Next(0, 27), "diamond", 1),
                    new ItemStack((ushort)rand.Next(0, 27), "gold_ingot", 1),
                    new ItemStack((ushort)rand.Next(0, 27), "iron_ingot", 1),
                    new ItemStack((ushort)rand.Next(0, 27), "redstone", 1)
                };
                commands.SetChestItems(chestPos, myItem);
            }
        }
    }
}