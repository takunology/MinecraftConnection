using System;
using System.Collections.Generic;
using System.Text;
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
        private List<Item> InventoryItems { get; set; }
        private Directions Direction { get; set; }

        public PlayerData(RCON rcon)
        {
            this.rcon = rcon;
        }
        /// <summary>
        /// プレイヤーの持ち物を取得します。
        /// </summary>
        /// <param name="PlayerName">プレイヤー名</param>
        public void GetInventoryItems(string PlayerName)
        {

        }
        /// <summary>
        /// プレイヤーの座標(x, y, z)を取得します。
        /// </summary>
        /// <param name="PlayerName"></param>
        public void GetCoordinate(string PlayerName)
        {
            int x = 0, y = 0, z = 0;

            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int PlayerPosX(string PlayerName)
        {
            GetCoordinate(PlayerName);
            return X;
        }
        public int PlayerPosY(string PlayerName)
        {
            GetCoordinate(PlayerName);
            return Y;
        }
        public int PlayerPosZ(string PlayerName)
        {
            GetCoordinate(PlayerName);
            return Z;
        }
    }
}
