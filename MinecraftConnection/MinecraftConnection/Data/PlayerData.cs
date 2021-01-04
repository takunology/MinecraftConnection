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
    public class PlayerData
    {
        private RCON rcon;

        private int X { get; set; }
        private int Y { get; set; }
        private int Z { get; set; }

        private List<Item> AllItems = new List<Item>();
        private List<Item> InventoryItems = new List<Item>();
        private List<Item> HandItems = new List<Item>();
        private Item LeftHandItem { get; set; }

        public PlayerData(RCON rcon)
        {
            this.rcon = rcon;
        }
        /// <summary>
        /// プレイヤーのx座標を取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int PlayerPosX(string PlayerName)
        {
            Task.Run(async () => { await GetCoordinateAsync(PlayerName); }).GetAwaiter().GetResult();
            return X;
        }
        /// <summary>
        /// プレイヤーのy座標を取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int PlayerPosY(string PlayerName)
        {
            Task.Run(async () => { await GetCoordinateAsync(PlayerName); }).GetAwaiter().GetResult();
            return Y;
        }
        /// <summary>
        /// プレイヤーのz座標を取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        /// <returns></returns>
        public int PlayerPosZ(string PlayerName)
        {
            Task.Run(async () => { await GetCoordinateAsync(PlayerName); }).GetAwaiter().GetResult();
            return Z;
        }
        /// <summary>
        /// プレイヤーの手持ちアイテムを取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        public List<Item> GetHandItems(string PlayerName)
        {
            Task.Run(async () => { await GetHandItemsAsync(PlayerName); }).GetAwaiter().GetResult();
            return this.HandItems;
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
        private void GetLeftHandItem(string PlayerName)
        {

        }

        private async Task GetCoordinateAsync(string PlayerName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/data get entity {PlayerName} Pos");
            string filterResult = Regex.Replace(result, @"[^0-9-,.]", "");
            string[] splitResult = filterResult.Split(',');
            float[] value = new float[]
            {
                float.Parse(splitResult[0]),
                float.Parse(splitResult[1]),
                float.Parse(splitResult[2]),
            };
            X = (int)value[0];
            Y = (int)value[1];
            Z = (int)value[2];
        }

        private async Task ExtractItemsAsync(string PlayerName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/data get entity {PlayerName} Inventory");

            result = result.Substring(result.IndexOf("["));
            result = Regex.Replace(result, @"[\[{\]\s]", "");
            string[] split_data = result.Split('}',',');

            int Items = 0;

            for (int i = 0; i < split_data.Length; i++)
            {
                if (split_data[i].Contains("Slot:"))
                    Items++;
            }

            int[] ItemSlot = new int[Items];
            string[] ItemID = new string[Items];
            int[] ItemCount = new int[Items];
            int l = 0, m = 0, n = 0;

            for (int i = 0; i < split_data.Length; i++)
            {
                string[] data = split_data[i].Split(',');

                for (int j = 0; j < data.Length; j++)
                {
                    if (data[j].Contains("Slot:"))
                    {
                        string strItemSlot = Regex.Replace(data[j], "[^0-9]", "");
                        ItemSlot[l] = int.Parse(strItemSlot);
                        l++;
                    }
                    else if (data[j].Contains("id:"))
                    {
                        data[j] = Regex.Replace(data[j], @"[^a-zA-Z:]", "");
                        ItemID[m] = data[j].Substring(data[j].IndexOf("minecraft"));
                        m++;
                    }
                    else if (data[j].Contains("Count:"))
                    {
                        string strCount = Regex.Replace(data[j], "[^0-9]", "");
                        ItemCount[n] = int.Parse(strCount);
                        n++;
                    }
                    else break;
                }
            }

            for (int i = 0; i < Items; i++)
            {
                AllItems.Add(new Item(ItemID[i], ItemCount[i], ItemSlot[i]));
            }
        }

        private async Task GetHandItemsAsync(string PlayerName)
        {
            await ExtractItemsAsync(PlayerName);
            foreach(var item in AllItems)
            {
                if (item.GetItemSlot() < 9) HandItems.Add(item);
            }
        }

        private async Task GetInventoryItemsAsync(string PlayerName)
        {
            await ExtractItemsAsync(PlayerName);
            foreach (var item in AllItems)
            {
                if (item.GetItemSlot() > 8) InventoryItems.Add(item);
            }
        }

        private void GetLeftHandItemAsync(string PlayerName)
        {

        }

    }
}
