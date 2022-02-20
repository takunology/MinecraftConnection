# MinecraftConnection
<div>
<img src="./images/logo.png" width="350" hspace="0" vspace="10">
</div>

![](https://img.shields.io/badge/Minecraft%20Version-1.15~-brightgreen)

日本語版は[こちら](https://github.com/takunology/MinecraftConnection/blob/main/README_JP.md)

MinecraftConnection is a library for sending commands via RCON using C# to help you learn and automate your programming. It can be run on a vanilla server as well as a Spigot server, including plugins. Before running the program, you need to start a Minecraft server that allows RCON connections.

# 1. Preparation
First, download the Minecraft Server software and run it in any game directory. A server configuration file called `server.properties` will be created. Specify the password and port number for the RCON connection, and enable the connection.

Configuration example :

```
rcon.port=25575
rcon.password=minecraft
enable-rcon=true
```

After adding it save the file and restart the server.   Launch Minecraft launcher and log in to the server. </br>

# 2. Create Project
This library is intended for `.NET Standard 2.0` and above. This section describes how to create a .NET 5 console application. 

Install `MinecraftConnection` with the NuGet package manager, or run the following command in the package manager console. 

```
Install-Package MinecraftConnection
```

Detail：https://www.nuget.org/packages/MinecraftConnection
</br>

# 3. Sample programs
To run the program, start Minecraft Server and Minecraft itself (already logged in to the server). 

Set the time to 0 :

```cs
using MinecraftConnection;

namespace ExampleApp
{
    class Program
    {
        // IP address or DNS name.
        static string address = "127.0.0.1";
        static ushort port = 25575;
        static string pass = "minecraft";
        static MinecraftCommands command = new MinecraftCommands(address, port, pass);

        static void Main(string[] args)
        {
            command.SendCommand("time set 0");
        }
    }
}
```
</br>
Set off fireworks :

```cs
using MinecraftConnection;
using MinecraftConnection.Items;

namespace ExampleApp
{
    class Program
    {
        static string address = "127.0.0.1";
        static ushort port = 25575;
        static string pass = "minecraft";
        static MinecraftCommands command = new MinecraftCommands(address, port, pass);

        static void Main(string[] args)
        {
            string playerName = "takunology";
            // Get player coordinates
            var playerData = command.GetPlayerData(playerName);
            int x = playerData.PositionX;
            int y = playerData.PositionY;
            int z = playerData.PositionZ;
            // Set Fireworks colors
            List<FireworksColors> explosionColor = new List<FireworksColors>() { FireworksColors.BLUE };
            List<FireworksColors> fadeColor = new List<FireworksColors>() { FireworksColors.CYAN };
            // Make the fireworks item
            Fireworks fireworks = new Fireworks(20, FireworksShapes.LargeBall, explosionColor, fadeColor).Trail();
            // Set off fireworks
            command.SetOffFireworks(x + 10, y, z, fireworks);
        }
    }
}
```

Result :

<img src="./images/fireworks_sample.png" width="550" hspace="0" vspace="10">

The stop command is disabled due to the risk of stopping the server by RCON remote control. Executing the stop command in SendCommand method will raise an exception.

</br>

Project Detail: https://www.mcwithcode.com/
