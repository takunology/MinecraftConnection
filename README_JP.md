# MinecraftConnection
<div>
<img src="https://raw.githubusercontent.com/takunology/MinecraftConnection/main/images/logo.png" width="350" hspace="0" vspace="10">
</div>

![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/MinecraftConnection)
![Nuget](https://img.shields.io/nuget/dt/MinecraftConnection?color=blue)
![](https://img.shields.io/badge/Minecraft%20Version-1.18~-brightgreen)
![GitHub](https://img.shields.io/github/license/takunology/MinecraftConnection)
 
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
本ライブラリは `.NET Standard 2.1` 以上が対象となっています。ここでは、.NET 6 コンソールアプリケーションを用いた作成方法をについて説明します。

NuGet パッケージマネージャにて `MinecraftConnection` をインストールするか、パッケージマネージャコンソールにて次のコマンドを実行します。

```
Install-Package MinecraftConnection
```
詳細：https://www.nuget.org/packages/MinecraftConnection
</br>

# 3. サンプルプログラム
プログラムを実行するにはMinecraft ServerおよびMinecraft本体（サーバへのログイン済み）を起動した状態で行ってください。</br>
ここではトップレベルステートメントを使用しています。

### 3.1 時間を 0 に設定するプログラム

```cs
using MinecraftConnection;

//接続先のIPアドレスまたはDNS名も利用可能です。
string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
MinecraftCommands command = new MinecraftCommands(address, port, pass);

command.TimeSet(0);
```
</br>

### 3.2 花火を打ち上げるプログラム

```cs
using MinecraftConnection;
using MinecraftConnection.Entity;

string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
MinecraftCommands command = new MinecraftCommands(address, port, pass);

// 打ち上げたい座標を定義する
Position pos = new Position(-516, 64, -205);
// 花火を作る
Fireworks fireworks = new Fireworks()
{
    LifeTime = 30, // 花火が爆発するまでの時間
    Type = FireworkType.LargeBall, // 花火の形状
    Colors = FireworkOption.RandomColor(), // 花火の色（ランダム）
    FadeColors = new List<FireworkColors> { FireworkColors.WHITE }, // 爆発後の色
};
// 花火を打ち上げる
command.SetOffFireworks(pos, fireworks);
```
実行結果

<img src="https://raw.githubusercontent.com/takunology/MinecraftConnection/main/images/fireworks_sample.png" width="550" hspace="0" vspace="10">

工夫次第で様々な花火を打ち上げることができます。試してみたい方はこちらを参考にしてください。

https://zenn.dev/takunology/scraps/9462b03d13dd0a

# 4. 注意事項
RCONの遠隔操作によってサーバを停止させる危険性があるため、`stop` コマンドは使用出来ないようになっています。`SendCommand` メソッドで `stop` コマンドを実行使用とすると例外が発生し、プログラムが止まるようになっています。

</br>

プロジェクト詳細: https://www.mcwithcode.com/
