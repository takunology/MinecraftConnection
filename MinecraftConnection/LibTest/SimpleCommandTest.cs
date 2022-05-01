using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinecraftConnection;
using System;

namespace LibTest
{
    [TestClass]
    public class SimpleCommandTest
    {
        static string address = "127.0.0.1";
        static ushort port = 25575;
        static string pass = "minecraft";
        static MinecraftCommands command = new MinecraftCommands(address, port, pass);

        //[TestMethod]
        public void SayCommandTest()
        {
            command.SendCommand("say Hello!");
            command.SendCommand("say こんにちは！");
            command.SendCommand("say 你好！");
            command.SendCommand("say Привет!");
            command.SendCommand("say नमस्कार!");
        }

        //[TestMethod]
        public void GetPlayerDataTest()
        {
            var result = command.SendCommand("data get entity Takunology");
            Console.WriteLine(result);
        }

        //[TestMethod]
        public void FireworkTest()
        {
            while (true)
            {
                command.SendCommand("/summon firework_rocket -490 63 -223 {LifeTime:30,FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:2,Explosions:[{Type:1,Flicker:0,Trail:0,Colors:[I;11743532]}]}}}}");
                command.Wait(2000);
                command.SendCommand("/summon firework_rocket -490 63 -223 {LifeTime:30,FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:2,Explosions:[{Type:1,Flicker:0,Trail:0,Colors:[I;3887386]}]}}}}");
                command.Wait(2000);
                command.SendCommand("/summon firework_rocket -490 63 -223 {LifeTime:30,FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:2,Explosions:[{Type:1,Flicker:0,Trail:0,Colors:[I;2437522]}]}}}}");
                command.Wait(2000);
                command.SendCommand("/summon firework_rocket -490 63 -223 {LifeTime:30,FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:2,Explosions:[{Type:1,Flicker:0,Trail:0,Colors:[I;15435844]}]}}}}");
                command.Wait(2000);
            }
        }
    }
}