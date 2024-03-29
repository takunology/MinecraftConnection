# MinecraftConnection
<div>
<img src="https://raw.githubusercontent.com/takunology/MinecraftConnection/main/images/logo.png" width="300" hspace="0" vspace="10">
</div>

![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/MinecraftConnection)
![Nuget](https://img.shields.io/nuget/dt/MinecraftConnection?color=blue)
![](https://img.shields.io/badge/Minecraft%20Version-1.18~-brightgreen)
![GitHub](https://img.shields.io/github/license/takunology/MinecraftConnection)

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
This library is intended for `.NET Standard 2.1` and above. This section describes how to create a .NET 6 console application. 

Install `MinecraftConnection` with the NuGet package manager, or run the following command in the package manager console. 

```
Install-Package MinecraftConnection
```

dotnet command:

```
dotnet add package MinecraftConnection
```

Detail：https://www.nuget.org/packages/MinecraftConnection
</br>

# 3. Sample programs
To run the program, start Minecraft Server and Minecraft itself (already logged in to the server). </br>
Top-level statements are used here.

## 3.1 Set the time to 0

```cs
using MinecraftConnection;

// IP address or DNS name.
string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
MinecraftCommands command = new MinecraftCommands(address, port, pass);

command.TimeSet(0);
```
</br>

## 3.2 Set off fireworks

```cs
using MinecraftConnection;
using MinecraftConnection.Entity;

string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
MinecraftCommands command = new MinecraftCommands(address, port, pass);

// Define the coordinates at which you want to launch
Position pos = new Position(-516, 64, -205);
// Make a fireworks
Fireworks fireworks = new Fireworks()
{
    LifeTime = 30, // Time to explosion
    Type = FireworkType.LargeBall, // Fireworks type
    Colors = FireworkOption.RandomColor(), // Fireworks color (RandomColor() is get random color)
    FadeColors = new List<FireworkColors> { FireworkColors.WHITE }, // after explosion color
};
// Set off fireworks at defined position
command.SetOffFireworks(pos, fireworks);
```

Result :

<img src="https://raw.githubusercontent.com/takunology/MinecraftConnection/main/images/fireworks_sample.png" width="550" hspace="0" vspace="10">

Various fireworks can be set off depending on your ingenuity. If you would like to try it, please refer to this page.

https://zenn.dev/takunology/scraps/9462b03d13dd0a

## 3.3 Sorting items in a chest
You can retrieve items in a chest and sort them by ID or by count.</br>
The following source code allows you to sort items by name by using the `SortById()` method on the retrieved item data. The `MinecraftConnection.Extends` directive declaration is required to use the sorting method.

```cs
using MinecraftConnection;
using MinecraftConnection.Extends;

string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
MinecraftCommands command = new MinecraftCommands(address, port, pass);

// Declare the coordinates of the "Chest block" or "Shulker box".
var pos = new Position(-502, 63, -213);
// Get the items in the chest.
var chestitems = command.GetChestItems(pos);
// Sort the acquired items and overwrite them in the chest again.
command.SetChestItems(pos, chestitems.SortByIdDescending());
```

Result:

<img src="https://raw.githubusercontent.com/takunology/MinecraftConnection/main/images/sort.gif" width="550" hspace="0" vspace="10">

## 3.4 Play sound
The `PlaySound()` method can be used to play Minecraft sound effects. Sound effects are stored in the `Sound` enumeration.

```cs
ushort sub = 230;
ushort main = 230;

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
```

Running example at X (Twitter)

https://twitter.com/takunology_net/status/1695049583615963590?s=20

# 4. Caution
The stop command is disabled due to the risk of stopping the server by RCON remote control. Executing the stop command in SendCommand method will raise an exception.

</br>

Project Detail: https://www.mcwithcode.com/
