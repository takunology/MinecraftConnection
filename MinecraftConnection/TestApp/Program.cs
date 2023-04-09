using MinecraftConnection;
using MinecraftConnection.Extends;

namespace TestApp
{
    internal class Program
    {
        static string address = "127.0.0.1";
        static ushort port = 25575;
        static string pass = "minecraft";
        static MinecraftCommands command = new MinecraftCommands(address, port, pass);

        static void Main(string[] args)
        {
            
        }
    }
}