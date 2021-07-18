using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MinecraftConnection.Items;
using MinecraftConnection.RCON;

namespace MinecraftConnection.Entity
{
    /// <summary>
    /// プレイヤーデータに関するクラスです。
    /// </summary>
    public partial class PlayerData
    {
        private readonly MinecraftRCON rcon;
        private string PlayerName { get; set; }
        /// <summary>
        /// プレイヤーのX座標
        /// </summary>
        public int PositionX { get; set; }
        /// <summary>
        /// プレイヤーのY座標
        /// </summary>
        public int PositionY { get; set; }
        /// <summary>
        /// プレイヤーのZ座標
        /// </summary>
        public int PositionZ { get; set; }
        /// <summary>
        /// プレイヤーが所持している全てのアイテム
        /// </summary>
        public List<SlotItem> AllItems { get; set; }
        /// <summary>
        /// プレイヤーのスロットに所持しているアイテム
        /// </summary>
        public List<SlotItem> MainHandItems { get; set; }
        /// <summary>
        /// プレイヤーのインベントリアイテム
        /// </summary>
        public List<SlotItem> InventoryItems { get; set; }
        /// <summary>
        /// プレイヤーの装備アイテム
        /// </summary>
        public List<SlotItem> Equipments { get; set; }
        /// <summary>
        /// プレイヤーの左手に所持しているアイテム
        /// </summary>
        public SlotItem LeftHandItem { get; set; }
        /// <summary>
        /// プレイヤーの満腹度（最大20）
        /// </summary>
        public int FoodLevel { get; set; }
        /// <summary>
        /// プレイヤーのスコア
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// プレイヤーの体力（最大20）
        /// </summary>
        public float Health { get; set; }

        public PlayerData(string PlayerName, MinecraftRCON rcon)
        {
            this.PlayerName = PlayerName;
            this.rcon = rcon;
            Initialize();
        }
    }

    public partial class PlayerData
    {
        private void Initialize()
        {
            Task.Run(async () =>
            {
                await GetPositionAsync();
                await GetItemsAsync();
                await GetFoodLevelAsync();
                await GetScoreAsync();
                await GetHealthAsync();

            }).GetAwaiter().GetResult();
        }

        private async Task GetPositionAsync()
        {
            string result = rcon.SendCommand($"data get entity {PlayerName} Pos");

            if (result.Contains("Not") || PlayerName == null)
                throw new Exception("プレイヤーが見つかりません。");

            string filterResult = Regex.Replace(result, @"[^0-9-,.]", "");
            string[] splitResult = filterResult.Split(',');
            float[] value = new float[]
            {
                float.Parse(splitResult[0]),
                float.Parse(splitResult[1]),
                float.Parse(splitResult[2]),
            };
            PositionX = (int)value[0];
            PositionY = (int)value[1];
            PositionZ = (int)value[2];
        }
        private async Task GetItemsAsync()
        {
            string result = rcon.SendCommand($"/data get entity {PlayerName} Inventory");

            if (result.Contains("No") || PlayerName == null)
                throw new Exception("プレイヤーが見つかりません。");

            result = result.Substring(result.IndexOf("["));
            result = Regex.Replace(result, @"[\[{\]\s]", "");
            string[] split_data = result.Split('}', ',');

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
                        data[j] = Regex.Replace(data[j], @"[^a-zA-Z:_]", "");
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

            AllItems = new List<SlotItem>();
            for (int i = 0; i < Items; i++)
            {
                AllItems.Add(new SlotItem(ItemSlot[i], ItemID[i], ItemCount[i]));
            }

            GetMainHandItems(AllItems);
            GetInventoryItems(AllItems);
            GetEquipments(AllItems);
            GetLeftHandItem(AllItems);
        }
        private void GetMainHandItems(List<SlotItem> AllItems)
        {
            MainHandItems = new List<SlotItem>();
            foreach (var item in AllItems)
            {
                if (item.ItemSlot < 9)
                    MainHandItems.Add(item);
            }
        }
        private void GetInventoryItems(List<SlotItem> AllItems)
        {
            InventoryItems = new List<SlotItem>();
            foreach (var item in AllItems)
            {
                if (item.ItemSlot > 8 && item.ItemSlot < 100)
                    InventoryItems.Add(item);
            }
        }
        private void GetEquipments(List<SlotItem> AllItems)
        {
            Equipments = new List<SlotItem>();
            foreach (var item in AllItems)
            {
                if (item.ItemSlot >= 100 && item.ItemSlot < 106)
                    Equipments.Add(item);
            }
        }
        private void GetLeftHandItem(List<SlotItem> AllItems)
        {
            foreach (var item in AllItems)
            {
                if (item.ItemSlot == 106)
                    LeftHandItem = item;
            }
        }
        private async Task GetFoodLevelAsync()
        {
            string result = rcon.SendCommand($"/data get entity {PlayerName} foodLevel");

            if (result.Contains("No") || PlayerName == "")
                throw new Exception("プレイヤーが見つかりません。プレイヤー名が正しいか確認してください。");

            string filterResult = Regex.Replace(result, @"[^0-9]", "");
            FoodLevel = int.Parse(filterResult);
        }
        private async Task GetScoreAsync()
        {
            string result = rcon.SendCommand($"/data get entity {PlayerName} Score");

            if (result.Contains("No") || PlayerName == "")
                throw new Exception("プレイヤーが見つかりません。プレイヤー名が正しいか確認してください。");

            string filterResult = Regex.Replace(result, @"[^0-9]", "");
            Score = int.Parse(filterResult);
        }
        private async Task GetHealthAsync()
        {
            string result = rcon.SendCommand($"/data get entity {PlayerName} Health");

            if (result.Contains("No") || PlayerName == "")
                throw new Exception("プレイヤーが見つかりません。プレイヤー名が正しいか確認してください。");

            string filterResult = Regex.Replace(result, @"[^0-9.]", "");
            Health = float.Parse(filterResult);
        }
    }
}
