using MinecraftConnection.Data;
using System.Collections.Generic;

namespace MinecraftConnection.Items
{
    public class EnchantedBook
    {
        /// <summary>
        /// エンチャント本をつくるためのクラスです。
        /// </summary>
        public Dictionary<Enchantments, int> Enchantments { get; set; }
        /// <summary>
        /// エンチャント本を作成します。
        /// </summary>
        /// <param name="Enchant">エンチャント名</param>
        /// <param name="EnchantLevel">エンチャントレベル</param>
        /// <remarks>Enchantments は名前空間 MinecraftConnection.Data を参照してください。</remarks>
        public EnchantedBook(Enchantments Enchant, int EnchantLevel)
        {
            this.Enchantments = new Dictionary<Enchantments, int>() { { Enchant, EnchantLevel } };
        }
        /// <summary>
        /// エンチャント本を作成します。
        /// </summary>
        /// <param name="Enchantments">エンチャントを定義した Dictionary </param>
        public EnchantedBook(Dictionary<Enchantments, int> Enchantments)
        {
            this.Enchantments = Enchantments;
        }
    }
}
