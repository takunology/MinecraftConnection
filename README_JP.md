# MinecraftConnection
<div>
<img src="./images/logo.png" width="350" hspace="0" vspace="10">
</div>

![](https://img.shields.io/badge/Minecraft%20Version-1.15~-brightgreen)
 
MinecraftConnectionはC#を用いてRCONでコマンドを送るためのライブラリです。マイクラによるC#プログラミングの学習や自動化に応用することができます。バニラ版（通常版）のサーバーだけでなく、プラグインを含むSpigotサーバーでも実行できます。プログラムを実行する前に、RCON 接続が可能な Minecraft サーバーを起動する必要があります。 </br>

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

NuGet パッケージマネージャにて `MinecraftConnection` をインストールするか、パッケージマネージャコンソールにて次のコマンドを実行します。

```
Install-Package MinecraftConnection
```
詳細：https://www.nuget.org/packages/MinecraftConnection
</br>

# 3. サンプルプログラム
プログラムを実行するにはMinecraft ServerおよびMinecraft本体（サーバへのログイン済み）を起動した状態で行ってください。

例）時間を 0 に設定するプログラム

```cs
using MinecraftConnection;

namespace ExampleApp
{
    class Program
    {
        //接続先のIPアドレスまたはDNS名も利用可能です。
        static string address = "127.0.0.1";
        static ushort port = 25575;
        static string pass = "minecraft";
        static MinecraftCommands command = new MinecraftCommands(address, port, pass);

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
            // プレイヤーの現在地を取得する
            var playerData = command.GetPlayerData(playerName);
            int x = playerData.PositionX;
            int y = playerData.PositionY;
            int z = playerData.PositionZ;
            // 花火の色を決める
            List<FireworksColors> explosionColor = new List<FireworksColors>() { FireworksColors.BLUE };
            List<FireworksColors> fadeColor = new List<FireworksColors>() { FireworksColors.CYAN };
            // 花火玉を作る
            Fireworks fireworks = new Fireworks(20, FireworksShapes.LargeBall, explosionColor, fadeColor).Trail();
            // 花火を打ち上げる
            command.SetOffFireworks(x + 10, y, z, fireworks);
        }
    }
}
```
実行結果

<img src="./images/fireworks_sample.png" width="550" hspace="0" vspace="10">

RCONの遠隔操作によってサーバを停止させる危険性があるため、`stop` コマンドは使用出来ないようになっています。`SendCommand` メソッドで `stop` コマンドを実行使用とすると例外が発生し、プログラムが止まるようになっています。

</br>

プロジェクト詳細: https://www.mcwithcode.com/
