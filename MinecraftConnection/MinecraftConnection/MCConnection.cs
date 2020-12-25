using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoreRCON;

namespace MinecraftConnection
{
    public class MCConnection
    {
        private RCON rcon;

        /// <summary>
        /// MinecraftConnection ライブラリ
        /// </summary>
        /// <param name="RconIPAddress">RCON接続用IPアドレス</param>
        /// <param name="RconPort">RCON接続用ポート番号</param>
        /// <param name="RconPassword">RCON接続用パスワード</param>
        public MCConnection(string RconIPAddress, ushort RconPort, string RconPassword)
        {
            rcon = new RCON(IPAddress.Parse(RconIPAddress), RconPort, RconPassword);
        }

        /// <summary>
        /// コマンドを送信します。
        /// </summary>
        /// <param name="Command">コマンド</param>
        public string SendCommand(string Command)
        {
            return Task.Run(async () => { return await AsyncSendCommand(Command); }).GetAwaiter().GetResult();
        }

        /// <summary>
        /// ブロックを配置します。
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="z">z座標</param>
        /// <param name="item">ブロック名</param>
        /// <returns></returns>
        public string SetBlock(int x, int y, int z, string item)
        {
            return Task.Run(async () => { return await AsyncSetBlock(x, y, z, item); }).GetAwaiter().GetResult();
        }

        /// <summary>
        /// 画面の真ん中に文字や数値を表示します。
        /// </summary>
        /// <param name="title">表示したい文字や数値</param>
        /// <returns></returns>
        public string DisplayTitle(object title)
        {
            return Task.Run(async () => { return await AsyncDisplayTitle(title.ToString()); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// チャット欄に文字や数値を表示します。
        /// </summary>
        /// <param name="message">表示したい文字や数値</param>
        /// <returns></returns>
        public string DisplayMessage(object message)
        {
            return Task.Run(async () => { return await AsyncDisplayMessage(message.ToString()); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 特定のプレイヤーにアイテムを与えます。
        /// </summary>
        /// <param name="player">プレイヤー名</param>
        /// <param name="item">アイテム名</param>
        /// <param name="count">アイテムの個数</param>
        /// <returns></returns>
        public string GiveItem(string player, string item, int count)
        {
            return Task.Run(async () => { return await AsyncGiveItem(player, item, count); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 特定のプレイヤーにバフまたはデバフを付与します。
        /// </summary>
        /// <param name="player">プレイヤー名</param>
        /// <param name="effect">バフまたはデバフ名</param>
        /// <param name="time">持続時間</param>
        /// <returns></returns>
        public string GiveEffect(string player, string effect, int time)
        {
            return Task.Run(async () => { return await AsyncGiveEffect(player, effect, time); }).GetAwaiter().GetResult();
        }

        private async Task<string> AsyncSendCommand(string str)
        {
            await rcon.ConnectAsync();
            if (!str.Contains("/"))
                str = "/" + str;
            return await rcon.SendCommandAsync(str);
        }
        
        private async Task<string> AsyncSetBlock(int x, int y, int z, string item)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/setblock {x} {y} {z} {item}");
        }

        private async Task<string> AsyncDisplayTitle(string str)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/title @a title \"{str}\"");
        }

        private async Task<string> AsyncDisplayMessage(string str)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/msg @a {str}");
        }

        private async Task<string> AsyncGiveItem(string player, string item, int count)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/give {player} {item} {count}");
        }

        private async Task<string> AsyncGiveEffect(string player, string effect, int time)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/effect give {player} {effect} {time}");
        }
    }
}
