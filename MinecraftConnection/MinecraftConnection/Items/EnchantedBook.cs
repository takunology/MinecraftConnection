using System;
using System.Collections.Generic;
using System.Text;

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
        /// <param name="Enchantments">エンチャントのリスト</param>
        public EnchantedBook(Dictionary<Enchantments, int> Enchantments)
        {
            this.Enchantments = Enchantments;
        }
    }
}
