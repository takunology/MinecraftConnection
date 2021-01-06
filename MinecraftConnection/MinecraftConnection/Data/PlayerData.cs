using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoreRCON;

using MinecraftConnection.Items;

namespace MinecraftConnection.Data
{
    //プレイヤーごとの情報が欲しいので動的
    public class PlayerData : PlayerDataBase
    {
        public PlayerData(RCON rcon)
        {
            this.rcon = rcon;
        }
        /// <summary>
        /// プレイヤーのx座標を取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int GetPosX(string PlayerName)
        {
            Task.Run(async () => { await ExtractCoordinateAsync(PlayerName); }).GetAwaiter().GetResult();
            return X;
        }
        /// <summary>
        /// プレイヤーのy座標を取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int GetPosY(string PlayerName)
        {
            Task.Run(async () => { await ExtractCoordinateAsync(PlayerName); }).GetAwaiter().GetResult();
            return Y;
        }
        /// <summary>
        /// プレイヤーのz座標を取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int GetPosZ(string PlayerName)
        {
            Task.Run(async () => { await ExtractCoordinateAsync(PlayerName); }).GetAwaiter().GetResult();
            return Z;
        }
        /// <summary>
        /// プレイヤーの手持ちアイテムを取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        public List<Item> GetHandItems(string PlayerName)
        {
            Task.Run(async () => { await GetHandItemsAsync(PlayerName); }).GetAwaiter().GetResult();
            return HandItems != null ? this.HandItems : throw new Exception("アイテムが存在しません。");
        }
        /// <summary>
        /// プレイヤーのインベントリアイテムを取得します。
        /// </summary>
        /// <param name="PlayerName"></param>
        public List<Item> GetInventoryItems(string PlayerName)
        {
            Task.Run(async () => { await GetInventoryItemsAsync(PlayerName); }).GetAwaiter().GetResult();
            return this.InventoryItems;            
        }
        /// <summary>
        /// プレイヤーの左手に持っているアイテムを取得します。
        /// </summary>
        /// <param name="PlayerName"></param>
        public Item GetLeftHandItem(string PlayerName)
        {
            Task.Run(async () => { await GetLeftHandItemAsync(PlayerName); }).GetAwaiter().GetResult();
            return this.LeftHandItem != null ? this.LeftHandItem : new Item("minecraft:air", 1, 106);
        }
        /// <summary>
        /// プレイヤーの装備アイテムを取得します。
        /// </summary>
        /// <param name="PlayerName"></param>
        /// <returns></returns>
        public List<Item> GetEquipmentItems(string PlayerName)
        {
            Task.Run(async () => { await GetEquipmentItemsAsync(PlayerName); }).GetAwaiter().GetResult();
            return this.Equipmets;
        }
        /// <summary>
        /// プレイヤーの満腹度を取得します(最大20)
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int GetFoodLevel(string PlayerName)
        {
            Task.Run(async () => { await GetFoodLevelAsync(PlayerName); }).GetAwaiter().GetResult();
            return this.FoodLevel;
        }

        private async Task GetHandItemsAsync(string PlayerName)
        {
            await ExtractItemsAsync(PlayerName);
            foreach(var item in AllItems)
            {
                if (item.GetItemSlot() < 9) HandItems.Add(item);
            }
            AllItems = new List<Item>();
        }

        private async Task GetInventoryItemsAsync(string PlayerName)
        {
            await ExtractItemsAsync(PlayerName);
            foreach (var item in AllItems)
            {
                if (item.GetItemSlot() > 8 && item.GetItemSlot() < 100) InventoryItems.Add(item);
            }
            AllItems = new List<Item>();
        }

        private async Task GetLeftHandItemAsync(string PlayerName)
        {
            await ExtractItemsAsync(PlayerName);
            foreach (var item in AllItems)
            {
                if (item.GetItemSlot() == 106) LeftHandItem = item;
            }
            AllItems = new List<Item>();
        }

        private async Task GetEquipmentItemsAsync(string PlayerName)
        {
            await ExtractItemsAsync(PlayerName);
            foreach (var item in AllItems)
            {
                if (item.GetItemSlot() >= 100 && item.GetItemSlot() < 106) Equipmets.Add(item);
            }
            AllItems = new List<Item>();
        }

        private async Task GetFoodLevelAsync(string PlayerName)
        {
            await ExtractFoodLevelAsync(PlayerName);
        }
    }
}
