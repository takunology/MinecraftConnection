using System;
using System.Collections.Generic;
using System.Text;
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
                NBT += "{" + $"id:{GetEnchantID(item.Key)},lvl:{item.Value}" + "},";
            }
            NBT = NBT.TrimEnd(',');
            NBT += "]}";
            // enchanted_book{StoredEnchantments:[{id:multishot,lvl:1},{id:power,lvl:1},{id:mending,lvl:1}]}
            return NBT;
        }

        private static string GetEnchantID(Enchantments Enchantment)
        {
            switch (Enchantment)
            {
                case Enchantments.AquaAffinity:
                    return "aqua_affinity";
                case Enchantments.BaneOfArthropods:
                    return "bane_of_arthropods";
                case Enchantments.BlastProtection:
                    return "blast_protection";
                case Enchantments.Channeling:
                    return "channeling";
                case Enchantments.CurseOfBinding:
                    return "binding_curse";
                case Enchantments.CurseOfVanishing:
                    return "vanishing_curse";
                case Enchantments.DepthStrider:
                    return "depth_strider";
                case Enchantments.Efficiency:
                    return "efficiency";
                case Enchantments.FeatherFalling:
                    return "feather_falling";
                case Enchantments.FireAspect:
                    return "fire_aspect";
                case Enchantments.FireProtection:
                    return "fire_protection";
                case Enchantments.Flame:
                    return "flame";
                case Enchantments.Fortune:
                    return "fortune";
                case Enchantments.FrostWalker:
                    return "frost_walker";
                case Enchantments.Impaling:
                    return "impaling";
                case Enchantments.Infinity:
                    return "infinity";
                case Enchantments.Knockback:
                    return "knockback";
                case Enchantments.Looting:
                    return "looting";
                case Enchantments.Loyality:
                    return "loyalty";
                case Enchantments.LuckOfTheSea:
                    return "luck_of_the_sea";
                case Enchantments.Lure:
                    return "lure";
                case Enchantments.Mending:
                    return "mending";
                case Enchantments.Multishot:
                    return "multishot";
                case Enchantments.Piercing:
                    return "piercing";
                case Enchantments.Power:
                    return "power";
                case Enchantments.ProjectileProtection:
                    return "projectile_protection";
                case Enchantments.Protection:
                    return "protection";
                case Enchantments.Punch:
                    return "punch";
                case Enchantments.QuickCharge:
                    return "quick_charge";
                case Enchantments.Respiration:
                    return "respiration";
                case Enchantments.Riptide:
                    return "riptide	";
                case Enchantments.Sharpness:
                    return "sharpness";
                case Enchantments.SilkTouch:
                    return "silk_touch";
                case Enchantments.Smite:
                    return "smite";
                case Enchantments.SoulSpeed:
                    return "soul_speed";
                case Enchantments.SweepingEdge:
                    return "sweeping";
                case Enchantments.Thorns:
                    return "thorns	";
                case Enchantments.Unbreaking:
                    return "unbreaking";
                default:
                    throw new Exception("存在しないエンチャント名です。");
            }
        }
    }
    //トロッコ加速プログラム -> 電車としての機能を付けたい
}
