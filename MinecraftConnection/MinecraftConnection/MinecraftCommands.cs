using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoreRCON;
using MinecraftConnection.Player;
using MinecraftConnection.Items;
using MinecraftConnection.NBT;

namespace MinecraftConnection
{
    /// <summary>
    /// Minecraft のコマンドリストです。
    /// </summary>
    public partial class MinecraftCommands
    {
        private RCON Rcon { get; set; }
        /// <summary>
        /// Minecraftのコマンドリストインスタンスを作ります。
        /// </summary>
        /// <param name="IpAddress">MinecraftServerのIPアドレス</param>
        /// <param name="Port">MinecraftServerのRCONポート番号</param>
        /// <param name="PassWord">MinecraftServerのRCONパスワード</param>
        public MinecraftCommands(IPAddress IpAddress, ushort Port, string PassWord)
        {
            Rcon = new RCON(IpAddress, Port, PassWord);
        }
    }
    // Minecraft 標準のコマンドリスト
    public partial class MinecraftCommands
    {
        /// <summary>
        /// コマンドを送信します。
        /// </summary>
        /// <param name="Command">Minecraftコマンド</param>
        /// <returns></returns>
        public string SendCommand(string Command)
        {
            return Task.Run(async () =>
            {
                if (!Command.Contains("/")) Command = "/" + Command;
                await Rcon.ConnectAsync();
                return await Rcon.SendCommandAsync(Command);
            }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Minecraftの画面中央に文字列を表示します。
        /// </summary>
        /// <param name="Text">表示する文字や数値</param>
        /// <returns></returns>
        public string DisplayTitle(object Text)
        {
            return Task.Run(async () =>
            {
                await Rcon.ConnectAsync();
                return await Rcon.SendCommandAsync($"/title @a title \"{Text}\"");
            }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Minecraftのログに文字列を表示します。
        /// </summary>
        /// <param name="Text">表示する文字や数値</param>
        /// <returns></returns>
        public string DisplayMessage(object Text)
        {
            return Task.Run(async () =>
            {
                await Rcon.ConnectAsync();
                return await Rcon.SendCommandAsync(Text.ToString());
            }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 指定した座標にブロックを設置します。
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="z">z座標</param>
        /// <param name="BlockItem">ブロック名</param>
        /// <returns></returns>
        public string SetBlock(int x, int y, int z, string BlockItem)
        {
            return Task.Run(async () =>
            {
                await Rcon.ConnectAsync();
                return await Rcon.SendCommandAsync($"/setblock {x} {y} {z} {BlockItem}");
            }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// プレイヤーにアイテムを与えます。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <param name="Item">アイテム名</param>
        /// <param name="Count">アイテムの個数</param>
        /// <returns></returns>
        public string GiveItem(string PlayerName, string Item, int Count)
        {
            return Task.Run(async () =>
            {
                await Rcon.ConnectAsync();
                return await Rcon.SendCommandAsync($"/give {PlayerName} {Item} {Count}");
            }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// プレイヤーにバフまたはデバフを付与します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <param name="Effect">バフまたはデバフ名</param>
        /// <param name="Count">効果時間</param>
        /// <returns></returns>
        public string GiveEffect(string PlayerName, string Effect, int Time)
        {
            return Task.Run(async () =>
            {
                await Rcon.ConnectAsync();
                return await Rcon.SendCommandAsync($"/effect give {PlayerName} {Effect} {Time}");
            }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 指定した座標にMobを召喚します。
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="z">z座標</param>
        /// <param name="Entity">Mobの名前</param>
        /// <returns></returns>
        public string Summon(int x, int y, int z, string Entity)
        {
            return Task.Run(async () =>
            {
                await Rcon.ConnectAsync();
                return await Rcon.SendCommandAsync($"/summon {Entity} {x} {y} {z}");
            }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// プレイヤーの所持アイテムを消去します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <param name="Item">アイテム名</param>
        /// <param name="Count">アイテムの個数</param>
        /// <returns></returns>
        public string ItemClear(string PlayerName, string Item, int Count)
        {
            return Task.Run(async () =>
            {
                await Rcon.ConnectAsync();
                return await Rcon.SendCommandAsync($"/clear {PlayerName} {Item} {Count}");
            }).GetAwaiter().GetResult();
        }
    }
    // MinecraftConnection 独自のコマンドリスト
    public partial class MinecraftCommands
    {
        /// <summary>
        /// プレイヤーのデータを取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public PlayerData GetPlayerData(string PlayerName)
        {
            return new PlayerData(PlayerName, Rcon);
        }
        /// <summary>
        /// チェスト内のアイテムを取得します。
        /// </summary>
        /// <param name="x">チェストの座標x</param>
        /// <param name="y">チェストの座標y</param>
        /// <param name="z">チェストの座標x</param>
        /// <returns></returns>
        public List<SlotItem> GetChestItems(int x, int y, int z)
        {
            return Task.Run(async () => 
            {
                ChestItem chestItem = new ChestItem(x, y, z, Rcon);
                return await chestItem.GetChestItemsAsync();
            }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// チェスト内のアイテムを変更します。
        /// </summary>
        /// <param name="x">チェストの座標x</param>
        /// <param name="y">チェストの座標y</param>
        /// <param name="z">チェストの座標x</param>
        /// <param name="SlotItemList">アイテムリスト</param>
        public void SetChestItems(int x, int y, int z, List<SlotItem> SlotItemList)
        {
            Task.Run(async () =>
            {
                ChestItem chestItem = new ChestItem(x, y, z, Rcon);
                await chestItem.SetChestItemsAsync(SlotItemList);
            }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 指定した座標から花火を打ち上げます。
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="z">z座標</param>
        /// <param name="fireworks">花火アイテム</param>
        public string SetOffFireworks(int x, int y, int z, Fireworks fireworks)
        {
            return Task.Run(async () =>
            {
                await Rcon.ConnectAsync();
                return await Rcon.SendCommandAsync($"/summon firework_rocket {x} {y} {z} {fireworks.ToNBT()}");
            }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// プレイヤーにエンチャント本を与えます。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <param name="Book">定義したエンチャント本</param>
        /// <param name="Count">本の数</param>
        /// <returns></returns>
        public string GiveEnchantedBook(string PlayerName, EnchantedBook Book, int Count)
        {
            return Task.Run(async () =>
            {
                await Rcon.ConnectAsync();
                return await Rcon.SendCommandAsync($"/give {PlayerName} enchanted_book{Book.ToNBT()} {Count}");
            }).GetAwaiter().GetResult();
        }
    }
}
