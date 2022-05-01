using MinecraftConnection;
using MinecraftConnection.Entity;

string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
MinecraftCommands command = new MinecraftCommands(address, port, pass);

var player = command.GetPlayerData("Takunology");

var fireworks = new FireworkEntity()
{

};

Console.WriteLine(fireworks.GetNBT());

while (true)
{
    command.SetOffFireworks((int)player.PosX, (int)player.PosY, (int)player.PosZ, fireworks);
    command.Wait(1000);
}

