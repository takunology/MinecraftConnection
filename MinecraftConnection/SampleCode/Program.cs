using MinecraftConnection;
using MinecraftConnection.Entity;

string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
MinecraftCommands command = new MinecraftCommands(address, port, pass);

var player = command.GetPlayerData("Takunology");

int x = -494;
int y = 65 + 30;
int z = -181;

var fireworks = new FireworkEntity()
{
    LifeTime = 30,
    Type = FireworkType.Burst,
    Flicker = true,
    Colors = new List<FireworkColors> { FireworkColors.YELLOW, FireworkColors.BLUE },
    FadeColors = new List<FireworkColors> { FireworkColors.RED },
};

Console.WriteLine(fireworks.GetNBT());

while (true)
{
    string str = command.SetOffFireworks(player.Postision, fireworks);
    player.GetPosition();
    Console.WriteLine(str);
    command.Wait(1000);
}

