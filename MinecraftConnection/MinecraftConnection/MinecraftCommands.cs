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
using MinecraftConnection.Design;
using System.Collections.Generic;
using MinecraftConnection.Items;

namespace MinecraftConnection
{
    public partial class MinecraftCommands
    {
        private RCON rcon { get; set; }

        /// <summary>
        /// Minecraft で使用するコマンドクラスです。
        /// </summary>
        /// <param name="rcon">RCONパラメータ</param>
        public MinecraftCommands(RCON rcon)
        {
            this.rcon = rcon;
        }
        /// <summary>
        /// コマンドを送信します。
        /// </summary>
        /// <param name="Command">コマンド</param>
        public string SendCommand(string Command)
        {
            return Task.Run(async () => { return await SendCommandAsync(Command); }).GetAwaiter().GetResult();
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
            return Task.Run(async () => { return await SetBlockAsync(x, y, z, item); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 画面の中央に文字や数値を表示します。
        /// </summary>
        /// <param name="title">表示したい文字や数値</param>
        /// <returns>実行結果</returns>
        public string DisplayTitle(object title)
        {
            return Task.Run(async () => { return await DisplayTitleAsync(title.ToString()); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// チャット欄に文字や数値を表示します。
        /// </summary>
        /// <param name="message">表示したい文字や数値</param>
        /// <returns>実行結果</returns>
        public string DisplayMessage(object message)
        {
            return Task.Run(async () => { return await DisplayMessageAsync(message.ToString()); }).GetAwaiter().GetResult();
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
            return Task.Run(async () => { return await GiveItemAsync(player, item, count); }).GetAwaiter().GetResult();
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
            return Task.Run(async () => { return await GiveEffectAsync(player, effect, time); }).GetAwaiter().GetResult();
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
            return Task.Run(async () => { return await SummonAsync(entity, x, y, z); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// プレイヤーの所持しているアイテムを消去します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <param name="Item">アイテム</param>
        /// <param name="Count">個数</param>
        /// <returns></returns>
        public string ItemClear(string PlayerName, string Item, int Count)
        {
            return Task.Run(async () => { return await ClearAsync(PlayerName, Item, Count); }).GetAwaiter().GetResult();
        }

    }
    
    public partial class MinecraftCommands
    {
        /// <summary>
        /// 指定した時間だけ待機します。
        /// </summary>
        /// <param name="time">ミリ秒</param>
        public void Wait(int time)
        {
            Task.Run(async () => { await Task.Delay(time); }).GetAwaiter().GetResult();
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
            return Task.Run(async () => { return await SetOffFireworksAsync(x, y, z, firework); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// プレイヤーのデータを取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public string GetPlayerData(string PlayerName)
        {
            return Task.Run(async () => { return await GetPlayerDataAsync(PlayerName); }).GetAwaiter().GetResult();
        }
        /// <summary>
        /// プレイヤーのインベントリアイテムを取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public List<Item> GetInventoryItems(string PlayerName)
        {
            PlayerData playerData = new PlayerData(rcon);
            return playerData.GetInventoryItems(PlayerName);
        }
        /// <summary>
        /// プレイヤーの手持ちアイテムを取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public List<Item> GetHandItems(string PlayerName)
        {
            PlayerData playerData = new PlayerData(rcon);
            return playerData.GetHandItems(PlayerName);
        }
        /// <summary>
        /// プレイヤーの装備アイテムを取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public List<Item> GetEquipmentItems(string PlayerName)
        {
            PlayerData playerData = new PlayerData(rcon);
            return playerData.GetEquipmentItems(PlayerName);
        }
        /// <summary>
        /// プレイヤーの左手のアイテムを取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public Item GetLeftHandItem(string PlayerName)
        {
            PlayerData playerData = new PlayerData(rcon);
            return playerData.GetLeftHandItem(PlayerName);
        }
        /// <summary>
        /// プレイヤーの現在地 (x座標) を取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int GetPlayerPosX(string PlayerName)
        {
            PlayerData playerData = new PlayerData(rcon);
            return playerData.GetPosX(PlayerName);
        }
        /// <summary>
        /// プレイヤーの現在地 (y座標) を取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int GetPlayerPosY(string PlayerName)
        {
            PlayerData playerData = new PlayerData(rcon);
            return playerData.GetPosY(PlayerName);
        }
        /// <summary>
        /// プレイヤーの現在地 (z座標) を取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int GetPlayerPosZ(string PlayerName)
        {
            PlayerData playerData = new PlayerData(rcon);
            return playerData.GetPosZ(PlayerName);
        }
        /// <summary>
        /// プレイヤーの満腹度を取得します(最大20)
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int GetFoodLevel(string PlayerName)
        {
            PlayerData playerData = new PlayerData(rcon);
            return playerData.GetFoodLevel(PlayerName);
        }
        /// <summary>
        /// プレイヤーのスコアを取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int GetScore(string PlayerName)
        {
            PlayerData playerData = new PlayerData(rcon);
            return playerData.GetScore(PlayerName);
        }
        /// <summary>
        /// プレイヤーの体力を取得します。(最大20.0)
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public float GetHealth(string PlayerName)
        {
            PlayerData playerData = new PlayerData(rcon);
            return playerData.GetHealth(PlayerName);
        }
        /// <summary>
        /// チェスト内のアイテムを取得します。
        /// </summary>
        /// <param name="x">チェストのx座標</param>
        /// <param name="y">チェストのy座標</param>
        /// <param name="z">チェストのz座標</param>
        /// <returns></returns>
        public List<Item> GetChestItems(int x, int y, int z)
        {
            ChestItems chestItems = new ChestItems(rcon);
            return chestItems.GetChestItems(x, y, z);
        }
        /// <summary>
        /// チェスト内のアイテムを書き換えます。
        /// </summary>
        /// <param name="x">チェストのx座標</param>
        /// <param name="y">チェストのy座標</param>
        /// <param name="z">チェストのz座標</param>
        /// <param name="ItemList">書きかえるアイテム（リスト）</param>
        /// <returns></returns>
        public string SetChestItems(int x, int y, int z, List<Item> ItemList)
        {
            ChestItems chestItems = new ChestItems(rcon);
            chestItems.SetChestItems(x, y, z, ItemList);
            return "Modified Chest Items";
        }
    }

    public partial class MinecraftCommands
    {
        private async Task<string> SendCommandAsync(string str)
        {
            await rcon.ConnectAsync();
            if (!str.Contains("/"))
                str = "/" + str;
            return await rcon.SendCommandAsync(str);
        }
        private async Task<string> SetBlockAsync(int x, int y, int z, string item)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/setblock {x} {y} {z} {item}");
        }
        private async Task<string> DisplayTitleAsync(string str)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/title @a title \"{str}\"");
        }
        private async Task<string> DisplayMessageAsync(string str)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/msg @a {str}");
        }
        private async Task<string> GiveItemAsync(string player, string item, int count)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/give {player} {item} {count}");
        }
        private async Task<string> GiveEffectAsync(string player, string effect, int time)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/effect give {player} {effect} {time}");
        }
        private async Task<string> SummonAsync(string entity, int x, int y, int z)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/summon {entity} {x} {y} {z}");
        }
        private async Task<string> SetOffFireworksAsync(int x, int y, int z, Firework firework)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/summon firework_rocket {x} {y} {z} {Firework.GetFireworkData(firework)}");
        }
        private async Task<string> GetPlayerDataAsync(string PlayerName)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/data get entity {PlayerName}");
        }
        private async Task<string> ClearAsync(string PlayerName, string Item, int Count)
        {
            await rcon.ConnectAsync();
            return await rcon.SendCommandAsync($"/clear {PlayerName} {Item} {Count}");
        }
    }
}
