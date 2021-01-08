using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoreRCON;
using MinecraftConnection.Items;

namespace MinecraftConnection.Data
{
    public class PlayerDataBase
    {
        protected RCON rcon;

        protected int X { get; set; }
        protected int Y { get; set; }
        protected int Z { get; set; }
        protected List<Item> AllItems = new List<Item>();
        protected List<Item> InventoryItems = new List<Item>();
        protected List<Item> HandItems = new List<Item>();
        protected List<Item> Equipmets = new List<Item>();
        protected Item LeftHandItem { get; set; }
        protected int FoodLevel { get; set; }
        protected int Score { get; set; }
        protected float Health { get; set; }

        protected async Task ExtractCoordinateAsync(string PlayerName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/data get entity {PlayerName} Pos");
            
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
            X = (int)value[0];
            Y = (int)value[1];
            Z = (int)value[2];
        }
        protected async Task ExtractItemsAsync(string PlayerName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/data get entity {PlayerName} Inventory");
            
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

            for (int i = 0; i < Items; i++)
            {
                AllItems.Add(new Item(ItemID[i], ItemCount[i], ItemSlot[i]));
            }
        }
        protected async Task ExtractFoodLevelAsync(string PlayerName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/data get entity {PlayerName} foodLevel");
            
            if (result.Contains("No") || PlayerName == "")
                throw new Exception("プレイヤーが見つかりません。プレイヤー名が正しいか確認してください。");

            string filterResult = Regex.Replace(result, @"[^0-9]", "");
            FoodLevel = int.Parse(filterResult);
        }
        protected async Task ExtractScoreAsync(string PlayerName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/data get entity {PlayerName} Score");

            if (result.Contains("No") || PlayerName == "")
                throw new Exception("プレイヤーが見つかりません。プレイヤー名が正しいか確認してください。");

            string filterResult = Regex.Replace(result, @"[^0-9]", "");
            Score = int.Parse(filterResult);
        }
        protected async Task ExtractHealthAsync(string PlayerName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/data get entity {PlayerName} Health");

            if (result.Contains("No") || PlayerName == "")
                throw new Exception("プレイヤーが見つかりません。プレイヤー名が正しいか確認してください。");

            string filterResult = Regex.Replace(result, @"[^0-9.]", "");
            Health = float.Parse(filterResult);
        }
    }
}
