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

        [TestMethod]
        public void GetPlayerDataTest()
        {
            var result = command.SendCommand("data get entity Takunology");
            Console.WriteLine(result);
        }
    }
}