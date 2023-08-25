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
            ushort sub = 230;
            ushort main = 230;

            // 4つ打ちドラム
            for(int i = 0; i < 3; i++)
            {
                command.PlaySound(Sound.Bell);
                command.Wait(430);
            }

            command.PlaySound(Sound.CowBell);
            command.Wait(430);

            for (int i = 0; i < 4; i++)
            {
                command.PlaySound(Sound.BaseDrum);
                command.Wait(sub);
                command.PlaySound(Sound.Hat);
                command.Wait(main);

                command.PlaySound(Sound.BaseDrum);
                command.PlaySound(Sound.Snare);
                command.Wait(sub);
                command.PlaySound(Sound.Hat);
                command.Wait(main);

                command.PlaySound(Sound.BaseDrum);
                command.Wait(sub);
                command.PlaySound(Sound.Hat);
                command.Wait(main);
                
                command.PlaySound(Sound.BaseDrum);
                command.PlaySound(Sound.Snare);
                command.Wait(sub);
                command.PlaySound(Sound.Hat);
                command.Wait(main);
            }
        }
    }
}