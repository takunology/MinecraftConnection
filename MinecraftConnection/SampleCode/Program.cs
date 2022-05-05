using MinecraftConnection;
using MinecraftConnection.Block;

string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
MinecraftCommands command = new MinecraftCommands(address, port, pass);

Position pos = new Position(-516, 62, -205);

ChestBlock chest = new ChestBlock(pos);
List<ItemStack> items = new List<ItemStack>()
{
    new ItemStack(0, "stone", 1),
    new ItemStack(1, "oak_planks", 1),
};

items.ForEach(item => Console.WriteLine($"{item.Slot}\t{item.Id}\t{item.Count}"));
chest.SetItems(items);


