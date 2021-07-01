# MinecraftConnection
<div>
<img src="./images/logo.png" width="350" hspace="0" vspace="10">
</div>

![](https://img.shields.io/badge/Minecraft%20Version-1.15~-brightgreen)
[![CircleCI](https://circleci.com/gh/takunology/MinecraftConnection/tree/main.svg?style=shield)](https://circleci.com/gh/takunology/MinecraftConnection/tree/main)
 
本ライブラリは、CoreRCONをベースにMinecraft用に拡張したものです。C#言語を用いてMinecraftにコマンドを送信することで、Minecraftプログラミングを可能にします。RCONの接続は非同期ですが、本ライブラリでは非同期のメソッドを宣言せずに使用することができます。本ライブラリを使用してプログラムを作成・実行する際には、RCON接続が設定されたマインクラフトサーバーを起動する必要があります。</br>

# 1. 準備
まずは Minecraft Server ソフトウェアをダウンロードし、任意のゲームディレクトリにて起動します。 `server.properties` というサーバ設定ファイルが作成されるので、RCON接続用のパスワードとポート番号を指定し、接続を有効にしてください。

設定例：

```
rcon.port=25575
rcon.password=minecraft
enable-rcon=true
```

追記したら保存してサーバを再起動します。また、マインクラフト本体を起動してサーバへのログインも済ませてください。</br>

# 2. プロジェクト作成
本ライブラリは `.NET Standard 2.0` 以上が対象となっています。ここでは、.NET 5 コンソールアプリケーションを用いた作成方法をについて説明します。

NuGet パッケージマネージャにて `MinecraftConnection` をインストールするか、パッケージマネージャコンソールにて次のコマンドを実行します。（現在はプレリリース版です。）

```
Install-Package MinecraftConnection -Version 1.0.0-beta1
```
詳細：https://www.nuget.org/packages/MinecraftConnection
</br>

# 3. サンプルプログラム
プログラムを実行するにはMinecraft ServerおよびMinecraft本体（サーバへのログイン済み）を起動した状態で行ってください。

例）時間を 0 に設定するプログラム

```cs
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
```
</br>
例）花火を打ち上げるプログラム

```cs
using System.Net;
using MinecraftConnection;
using MinecraftConnection.Items;

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
            string playerName = "takunology";
            // プレイヤーの現在地を取得する
            var playerData = command.GetPlayerData(playerName);
            int x = playerData.PositionX;
            int y = playerData.PositionY;
            int z = playerData.PositionZ;
            // 花火の色を決める
            List<FireworksColors> explosionColor = new List<FireworksColors>() { FireworksColors.BLUE };
            List<FireworksColors> fadeColor = new List<FireworksColors>() { FireworksColors.CYAN };
            // 花火玉を作る
            Fireworks fireworks = new Fireworks(20, 2, FireworksShapes.LargeBall, false, true, explosionColor, fadeColor);
            // 花火を打ち上げる
            command.SetOffFireworks(x + 10, y, z, fireworks);
        }
    }
}
```
実行結果

<img src="./images/fireworks_sample.png" width="550" hspace="0" vspace="10">

</br>

プロジェクト詳細: https://www.mcwithcode.com/