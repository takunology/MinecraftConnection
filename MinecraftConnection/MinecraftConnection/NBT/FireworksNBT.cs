using System.Collections.Generic;
using MinecraftConnection.ItemsBase;

namespace MinecraftConnection.NBT
{
    public static class FireworksNBT
    {
        /// <summary>
        /// 花火のNBTタグを取得します。
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public static string ToNBT(this Fireworks Item)
        {
            string NBT = "{LifeTime:" + Item.LifeTime
                + ",FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:" + Item.FlightDuration
                + ",Explosions:[{Type:" + Item.Shape
                + ",Flicker:" + BoolToString(Item.Flicker)
                + ",Trail:" + BoolToString(Item.Trail)
                + ",Colors:[I;" + ColorToString(Item.ExplosionColors)
                + "],FadeColors:[I;" + ColorToString(Item.FadeColors) + "]}]}}}}";
            return NBT;
        }

        private static string BoolToString(bool Item)
        {
            return Item == true ? "1" : "0";
        }
        private static string ColorToString(List<FireworksColors> ColorsList)
        {
            string Colors = "";
            foreach(var item in ColorsList)
            {
                Colors += item.GetHashCode() + ",";
            }
            Colors = Colors.TrimEnd(',');
            return Colors;
        }
    }
}
