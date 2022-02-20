using MinecraftConnection;
using CoreRCON;

MinecraftCommands command = new MinecraftCommands("127.0.0.1", 25575, "minecraft");
var result = command.SendCommand("say MinecraftConnection > こんにちは");
Console.WriteLine(result);