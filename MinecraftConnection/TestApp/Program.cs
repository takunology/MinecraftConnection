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
            var fw = new FireworkRocket()
            {
                LifeTime = 0,
                HasTrail = true,
                Shape = FireworkShape.Burst
            };

            var empty = new FireworkRocket()
            {
                LifeTime = 20,
                IsEmpty = true
            };

            for (int i = 0; i < 1000; i++)
            {
                empty.Motion = new Motion(2, -0.2, 0.0);
                Console.WriteLine(empty.GetNBT());
                command.Summon(empty, 51, 75, 600);
                Thread.Sleep(10);
            }
            
        }
    }
}