# MinecraftConnection
<div>
<img src="https://raw.githubusercontent.com/takunology/MinecraftConnection/main/images/logo.png" width="350" hspace="0" vspace="10">
</div>

![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/MinecraftConnection)
![Nuget](https://img.shields.io/nuget/dt/MinecraftConnection?color=blue)
![](https://img.shields.io/badge/Minecraft%20Version-1.20.5~-brightgreen)
![GitHub](https://img.shields.io/github/license/takunology/MinecraftConnection)
 
MinecraftConnection は RCON を介し C# でコマンドを送るためのライブラリです。マイクラによるC#プログラミングの学習や自動化に応用することができます。バニラ版（通常版）のサーバーだけでなく、プラグインを含むSpigotサーバーでも実行できます。プログラムを実行する前に、RCON 接続が可能な Minecraft サーバーを起動する必要があります。 </br>

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
本ライブラリは `.NET Standard 2.1` 以上が対象となっています。ここでは、.NET 9 コンソールアプリケーションを用いた作成方法をについて説明します。

dotnet コマンドで `MincraftConnection` を導入します。
```
dotnet add package MinecraftConnection --version 3.0.0-beta
```

詳細：https://www.nuget.org/packages/MinecraftConnection
</br>

# 3. サンプルプログラム
プログラムを実行するにはMinecraft ServerおよびMinecraft本体（サーバへのログイン済み）を起動した状態で行ってください。</br>
ここではトップレベルステートメントを使用しています。

バージョン3.X以降では `MinecraftCommands` から `MinecraftCommand` へ変更になりました。また、IDisposableを実装しているため、Disposeでリソースを解放するか、usingを使用するかをおすすめします。

## 3.1 時間を 0 に設定するプログラム

```cs
using MinecraftConnection;

//接続先のIPアドレスまたはDNS名も利用可能です。
string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
using var command = new MinecraftCommand(address, port, pass);

command.TimeSet(0);
```
</br>

## 3.2 花火を打ち上げるプログラム

```cs
using MinecraftConnection;
using MinecraftConnection.Entity;

string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
using var command = new MinecraftCommand(address, port, pass);

// 打ち上げたい座標を定義する
var pos = new Position(-516, 64, -205);
// 花火を作る
var fw = new FireworkRocket
{
    Colors = FireworkOption.GetRandomColors(), // 花火の色（ランダム）,
    FadeColors = new List<FireworkColor> { FireworkColor.YELLOW }, // 爆発後の色
    LifeTime = 20, // 花火が爆発するまでの時間
    Shape = FireworkShape.LargeBall, // 花火の形状
};
// 花火を打ち上げる
command.Summon(fw, -14, 63, -17);
```
実行結果

<img src="https://raw.githubusercontent.com/takunology/MinecraftConnection/main/images/fireworks.webp" width="550" hspace="0" vspace="10">

工夫次第で様々な花火を打ち上げることができます。試してみたい方はこちらを参考にしてください。

https://zenn.dev/takunology/scraps/9462b03d13dd0a

## 3.3 チェスト内のアイテムを変更する
チェストにアイテム情報を書き込むことができます。 </br>
ItesmStack型を使用して、アイテムのID、アイテム名、アイテムの数量を定義します。

```cs
using MinecraftConnection;

string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";

using var command = new MinecraftCommand(address, port, pass);

// アイテムを定義する
var items = new List<ItemStack>
{
    new ItemStack(0, "minecraft:stone", 64), // スロット0番目に石ブロック64個
    new ItemStack(1, "minecraft:diamond_sword", 1) // スロット1番目にダイヤモンドの剣1個
};
 
command.DataModifyBlock(-14, 63, -21, "Items", items);
```

`DaytaModifyBlock()` メソッドの第4引数は `data modify block` コマンドのNBT属性を指定する部分と同じです。第5引数にはその属性のデータ値を入力します。似たようなメソッドに `DataModifyEntity()` もありますが、これも "Pos" や "Motion" といった属性を指定することができます。ただし、文字列型のため、該当する文字列（属性）がない場合はエラーとなります。

# 4. 非同期メソッド
バージョン3.X以降では非同期メソッドもサポートしています。例えば Windows App SDK (WinUI) の Canvas と組み合わせることで、プレイヤーの位置情報をリアルタイムにマッピングするアプリをつくることができます。
取得した位置情報をリストに格納し、それをCanvasに描画します。

```html
<Window
    x:Class="GuiApp.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:GuiApp"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Title="GuiApp">

    <Window.SystemBackdrop>
        <MicaBackdrop />
    </Window.SystemBackdrop>

    <Grid>
        <Canvas x:Name="MotionCanvas" Background="White"/>
    </Grid>
</Window>
```

```cs
using MinecraftConnection;

public sealed partial class MainWindow : Window
{
    private List<Position> playerMotions = new List<Position>();
    public MainWindow()
    {
        InitializeComponent();

        CompositionTarget.Rendering += OnRender;
        StartMotionUpdate();
    }

    private async void StartMotionUpdate()
    {
        var command = new MinecraftCommand("127.0.0.1", 25575, "your-pass");
        while (true)
        {
            var data = await command.DataGetEntityAsync("player-name");
            var info = data.Position;

            DispatcherQueue.TryEnqueue(() =>
            {
                if (playerMotions.Count > 200)
                {
                    playerMotions.RemoveAt(0);
                }
                playerMotions.Add(info);
            });
            System.Diagnostics.Debug.WriteLine($"X:{info.X} Y:{info.Y} Z:{info.Z}");
            await Task.Delay(5);
        }
    }

    private void OnRender(object? sender, object e)
    {
        MotionCanvas.Children.Clear();

        double canvasWidth = MotionCanvas.ActualWidth;
        double canvasHeight = MotionCanvas.ActualHeight;
        double scale = 20;

        foreach (var motion in playerMotions)
        {
            var ellipse = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0))
            };

            // Canvas 中心を (0,0) として座標をマッピング
            double x = canvasWidth / 2 + motion.X * scale;
            double y = canvasHeight / 2 - motion.Z * scale; // Z を Y に投影

            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);
            MotionCanvas.Children.Add(ellipse);
        }
    }
}
```

実行結果：

<img src="https://raw.githubusercontent.com/takunology/MinecraftConnection/main/images/gui.gif" width="550" hspace="0" vspace="10">

実装方法の詳細はこちら：
https://zenn.dev/takunology/scraps/075d57bfcc5aaa

# 5. 注意事項
RCONの遠隔操作によってサーバを停止させる危険性があるため、`stop` コマンドは使用出来ないようになっています。`SendCommand` メソッドで `stop` コマンドを実行使用とすると例外が発生し、プログラムが止まるようになっています。

</br>

プロジェクト詳細: https://www.mcwithcode.com/
