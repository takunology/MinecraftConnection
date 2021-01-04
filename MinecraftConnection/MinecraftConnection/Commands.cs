/*
 * === CoreRCON ===
 * Copyright (c) 2017 Scott Kaye
 * Released under the MIT license
 * https://github.com/ScottKaye/CoreRCON/blob/master/LICENSE
 */

using System.Net;
using System.Threading.Tasks;
using CoreRCON;

using MinecraftConnection.FireworkItems;
using MinecraftConnection.Data;

namespace MinecraftConnection
{
    public class Commands
    {
        private readonly RCON rcon;
        /// <summary>
        /// Minecraft で使用するコマンドクラスです。
        /// </summary>
        /// <param name="rcon">RCONパラメータ</param>
        public Commands(RCON rcon)
        {
            this.rcon = rcon;
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
        /// <returns>実行結果</returns>
        public string SetBlock(int x, int y, int z, string item)
        {
            return Task.Run(async () => { return await AsyncSetBlock(x, y, z, item); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 画面の真ん中に文字や数値を表示します。
        /// </summary>
        /// <param name="title">表示したい文字や数値</param>
        /// <returns>実行結果</returns>
        public string DisplayTitle(object title)
        {
            return Task.Run(async () => { return await AsyncDisplayTitle(title.ToString()); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// チャット欄に文字や数値を表示します。
        /// </summary>
        /// <param name="message">表示したい文字や数値</param>
        /// <returns>実行結果</returns>
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
        /// <returns>実行結果</returns>
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
        /// <returns>実行結果</returns>
        public string GiveEffect(string player, string effect, int time)
        {
            return Task.Run(async () => { return await AsyncGiveEffect(player, effect, time); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 指定した座標にエンティティMobを召喚します。
        /// </summary>
        /// <param name="entity">エンティティ名</param>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="z">z座標</param>
        /// <returns>実行結果</returns>
        public string Summon(string entity, int x, int y, int z)
        {
            return Task.Run(async () => { return await AsyncSummon(entity, x, y, z); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 指定した座標から花火を打ち上げます
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="z">z座標</param>
        /// <param name="fireworks">花火の種類</param>
        /// <returns>実行結果</returns>
        public string SetOffFireworks(int x, int y, int z, Firework firework)
        {
            return Task.Run(async () => { return await AsyncSetOffFireworks(x, y, z, firework); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 指定した時間だけ待機します。
        /// </summary>
        /// <param name="time">ミリ秒</param>
        public void Wait(int time)
        {
            Task.Run(async () => { await Task.Delay(time); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// プレイヤーのデータを取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public string GetPlayerData(string PlayerName)
        {
            return Task.Run(async () => { return await AsyncGetPlayerData(PlayerName); }).GetAwaiter().GetResult();
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

        private async Task<string> AsyncSummon(string entity, int x, int y, int z)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/summon {entity} {x} {y} {z}");
        }

        private async Task<string> AsyncSetOffFireworks(int x, int y, int z, Firework firework)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/summon firework_rocket {x} {y} {z} {Firework.GetFireworkData(firework)}");
        }

        private async Task<string> AsyncGetPlayerData(string PlayerName)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/data get entity {PlayerName}");
        }
    }
}
