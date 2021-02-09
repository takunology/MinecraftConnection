using System;
using System.Collections.Generic;
using System.Text;

using MinecraftConnection.Items;

namespace MinecraftConnection.Player
{
    public partial class PlayerData : RconSettings
    {
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
        /// プレイヤーのスロットに所持しているアイテム
        /// </summary>
        public List<SlotItem> MainHand { get; set; }
        /// <summary>
        /// プレイヤーのインベントリアイテム
        /// </summary>
        public List<SlotItem> Inventory { get; set; }
        /// <summary>
        /// プレイヤーの装備アイテム
        /// </summary>
        public List<SlotItem> Equipments { get; set; }
        /// <summary>
        /// プレイヤーの左手に所持しているアイテム
        /// </summary>
        public SlotItem LeftHand { get; set; }

        public PlayerData(string PlayerName)
        {
            this.PlayerName = PlayerName;
            GetPositionX();
        }
    }

    public partial class PlayerData
    {
        private void GetPositionX()
        {
            Rcon.ConnectAsync();
        }
    }
}
