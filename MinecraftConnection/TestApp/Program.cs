using MinecraftConnection;
using MinecraftConnection.Entities;
using MinecraftConnection.Tools;

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

            var player = command.DataGetEntity("takunology");
            Console.WriteLine(player.Name);
            Console.WriteLine($"{player.Position.X} {player.Position.Y} {player.Position.Z}");

            var fw = new FireworkRocket
            {
                LifeTime = 20,
                Colors = FireworkOption.GetRandomColors()
            };

            command.Summon(fw, player.Position.X, player.Position.Y + 3, player.Position.Z);
        }
    }
}