using System.Collections.Generic;
using System.Threading.Tasks;
using MinecraftConnection.RCON;
using MinecraftConnection.Entity;
using MinecraftConnection.Items;
using MinecraftConnection.NBT;
using MinecraftConnection.Data;

namespace MinecraftConnection
{
    public partial class MinecraftCommands
    {
        private readonly MinecraftRCON rcon;

        public MinecraftCommands(string address, ushort port, string password)
        {
            rcon = new MinecraftRCON(address, port, password);
        }
    }
    // Minecraft 標準のコマンドリスト
    public partial class MinecraftCommands
    {
        public string SendCommand(string command)
        {
            return rcon.SendCommand(command);
        }

        public string DisplayTitle(object Text)
        {
            return rcon.SendCommand($"title @a title \"{Text}\"");
        }

        public string DisplayMessage(object Text)
        {
            return rcon.SendCommand(Text.ToString());
        }

        public string SetBlock(int x, int y, int z, string BlockItem)
        {
            return rcon.SendCommand($"setblock {x} {y} {z} {BlockItem}");
        }

        public string GiveItem(string PlayerName, string Item, int Count)
        {
            return rcon.SendCommand($"give {PlayerName} {Item} {Count}");
        }

        public string GiveEffect(string PlayerName, Effects Effect, int Time)
        {
            return rcon.SendCommand($"effect give {PlayerName} {Effect} {Time}");
        }

        public string GiveEffect(int x, int y, int z, string Entity)
        {
            return rcon.SendCommand($"summon {Entity} {x} {y} {z}");
        }

        public string ItemClear(string PlayerName, string Item, int Count)
        {
            return rcon.SendCommand($"clear {PlayerName} {Item} {Count}");
        }

        public void Wait(int Time)
        {
            Task.Run(async () =>
            {
                await Task.Delay(Time);
            }).GetAwaiter().GetResult();
        }
    }
    // MinecraftConnection 独自のコマンドリスト
    public partial class MinecraftCommands
    {
        public PlayerData GetPlayerData(string PlayerName)
        {
            return new PlayerData(PlayerName, rcon);
        }

        public List<SlotItem> GetChestItems(int x, int y, int z)
        {
            ChestItem chestItem = new ChestItem(x, y, z, rcon);
            return chestItem.GetChestItems();
        }

        public void SetChestItems(int x, int y, int z, List<SlotItem> SlotItemList)
        {
            ChestItem chestItem = new ChestItem(x, y, z, rcon);
            chestItem.SetChestItems(SlotItemList);
        }

        public string SetOffFireworks(int x, int y, int z, Fireworks fireworks)
        {
            return rcon.SendCommand($"summon firework_rocket {x} {y} {z} {fireworks.ToNBT()}");
        }

        public string GiveEnchantedBook(string PlayerName, EnchantedBook Book, int Count)
        {
            return rcon.SendCommand($"give {PlayerName} enchanted_book{Book.ToNBT()} {Count}");
        }

        public string GivePotion(string PlayerName, Potion Potion, int Count)
        {
            return  rcon.SendCommand($"give {PlayerName} potion{Potion.ToNBT()} {Count}");
        }
    }
}
