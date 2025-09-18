using MinecraftConnection;
using MinecraftConnection.Entity;

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
            command.SendCommand("Stop");
            
        }
    }
}