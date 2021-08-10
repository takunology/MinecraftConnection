using System;
using System.Collections.Generic;

namespace MinecraftConnection.Items
{
    public static class FireworksOptions
    {
        /// <summary>
        /// きらめき効果を付与します。
        /// </summary>
        public static Fireworks Trail(this Fireworks fireworks)
        {
            return new Fireworks(fireworks.LifeTime, fireworks.Shape, fireworks.ExplosionColors, fireworks.FadeColors)
            {
                LifeTime = 20,
                Shape = fireworks.Shape,
                Flicker = fireworks.Flicker,
                Trail = true,
                ExplosionColors = fireworks.ExplosionColors,
                FadeColors = fireworks.FadeColors,
                MotionX = fireworks.MotionX,
                MotionY = fireworks.MotionY,
                MotionZ = fireworks.MotionZ
            };
        }

        public static Fireworks Flicker(this Fireworks fireworks)
        {
            return new Fireworks(fireworks.LifeTime, fireworks.Shape, fireworks.ExplosionColors, fireworks.FadeColors)
            {
                LifeTime = 20,
                Shape = fireworks.Shape,
                Flicker = true,
                Trail = fireworks.Trail,
                ExplosionColors = fireworks.ExplosionColors,
                FadeColors = fireworks.FadeColors,
                MotionX = fireworks.MotionX,
                MotionY = fireworks.MotionY,
                MotionZ = fireworks.MotionZ
            };
        }

        public static Fireworks Motion(this Fireworks fireworks, double x, double y, double z)
        {
            return new Fireworks(fireworks.LifeTime, fireworks.Shape, fireworks.ExplosionColors, fireworks.FadeColors)
            {
                LifeTime = 20,
                Shape = fireworks.Shape,
                Flicker = fireworks.Flicker,
                Trail = fireworks.Trail,
                ExplosionColors = fireworks.ExplosionColors,
                FadeColors = fireworks.FadeColors,
                MotionX = x,
                MotionY = y,
                MotionZ = z
            };
        }

        /// <summary>
        /// 花火の色をランダムで取得します。
        /// </summary>
        /// <param name="count">取得する色の数</param>
        /// <returns></returns>
        public static List<FireworksColors> RandomColors(byte count)
        {
            var fireworksColors = new List<FireworksColors>();
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                fireworksColors.Add(SelectColor(rand.Next(0, 15)));
            }
            return fireworksColors;
        }
        /// <summary>
        /// 花火の色を指定した範囲内かつランダムで取得します。
        /// </summary>
        /// <param name="min">最低数</param>
        /// <param name="max">最高数</param>
        /// <returns></returns>
        public static List<FireworksColors> RandomColors(byte min, byte max)
        {
            var fireworksColors = new List<FireworksColors>();
            var rand = new Random();
            for (int i = rand.Next(0, min); i < rand.Next(min, max); i++)
            {
                fireworksColors.Add(SelectColor(rand.Next(0, 15)));
            }
            return fireworksColors;
        }

        private static FireworksColors SelectColor(int val)
        {
            switch (val)
            {
                case 0:
                    return FireworksColors.BLACK;
                case 1:
                    return FireworksColors.BLUE;
                case 2:
                    return FireworksColors.CYAN;
                case 3:
                    return FireworksColors.GREEN;
                case 4:
                    return FireworksColors.LIME;
                case 5:
                    return FireworksColors.GRAY;
                case 6:
                    return FireworksColors.BROWN;
                case 7:
                    return FireworksColors.LIGHTBLUE;
                case 8:
                    return FireworksColors.PURPLE;
                case 9:
                    return FireworksColors.LIGHTGRAY;
                case 10:
                    return FireworksColors.RED;
                case 11:
                    return FireworksColors.MAGENTA;
                case 12:
                    return FireworksColors.PINK;
                case 13:
                    return FireworksColors.YELLOW;
                case 14:
                    return FireworksColors.ORANGE;
                default:
                    return FireworksColors.WHITE;
            }
        }
    }
}
