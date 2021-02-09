using System;
using System.Net;
using MinecraftConnection;

namespace TestApp
{
    class Program
    {
        static IPAddress Address = IPAddress.Parse("127.0.0.1");
        static ushort Port = 25575;
        static string Pass = "minecraft";
        static MinecraftCommands Commands = new MinecraftCommands(Address, Port, Pass);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var PlayerData = Commands.GetPlayerData("Takunology");
            Console.WriteLine(PlayerData.PositionX);
        }
    }
}
