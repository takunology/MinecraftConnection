using MinecraftConnection.Data;
using MinecraftConnection.Items;

namespace MinecraftConnection.NBT
{
    public static class EnchantmentsNBT
    {
        /// <summary>
        /// エンチャントブックのエンチャントとレベルをNBTに変換します。
        /// </summary>
        /// <param name="Enchantments">エンチャントブック</param>
        /// <returns></returns>
        public static string ToNBT(this EnchantedBook Enchantments)
        {
            string NBT = "{StoredEnchantments:[";
            foreach (var item in Enchantments.Enchantments)
            {
                NBT += "{" + $"id:{item.Key.GetMinecraftID()},lvl:{item.Value}" + "},";
            }
            NBT = NBT.TrimEnd(',');
            NBT += "]}";
            return NBT;
        }
    }
}
