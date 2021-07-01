using System.Net;
using MinecraftConnection;

namespace ExampleApp
{
    class Program
    {
        private static readonly IPAddress _address = IPAddress.Parse("127.0.0.1");
        private static readonly ushort _port = 25575;
        private static readonly string _pass = "minecraft";
        private static MinecraftCommands command = new MinecraftCommands(_address, _port, _pass);

        static void Main(string[] args)
        {
            command.SendCommand("/time set 0");
        }
    }
}