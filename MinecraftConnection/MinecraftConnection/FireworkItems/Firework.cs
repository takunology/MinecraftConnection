using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.FireworkItems
{
    public class Firework
    {
        private int LifeTime { get; set; }
        private int FlightDuration { get; set; }
        private FireworksShapes Shape { get; set; }
        private bool Flicker { get; set; }
        private bool Trail { get; set; }
        private List<FireworksColors> ExplosionColors { get; set; }
        private List<FireworksColors> FadeColors { get; set; }

        /// <summary>
        /// 花火のインスタンスをつくります。
        /// </summary>
        /// <param name="LifeTime">花火が咲くまでの時間</param>
        /// <param name="FlightDuration">飛行時間</param>
        /// <param name="Shape">花火が咲いたときの形状</param>
        /// <param name="Flicker">ちらつきの有無</param>
        /// <param name="Trail">しだれの有無</param>
        /// <param name="ExplosionColors">咲いたときの色</param>
        /// <param name="FadeColors">散るときの色</param>
        public Firework(int LifeTime, byte FlightDuration, FireworksShapes Shape, bool Flicker, bool Trail, List<FireworksColors> ExplosionColors, List<FireworksColors> FadeColors)
        {
            this.LifeTime = LifeTime;
            this.FlightDuration = SetFlightDuration(FlightDuration);
            this.Shape = Shape;
            this.Flicker = Flicker;
            this.Trail = Trail;
            this.ExplosionColors = ExplosionColors;
            this.FadeColors = FadeColors;
        }

        /// <summary>
        /// 花火のインスタンスをつくります。
        /// </summary>
        /// <param name="LifeTime">花火が咲くまでの時間</param>
        /// <param name="FlightDuration">飛行時間</param>
        /// <param name="Shape">花火が咲いたときの形状</param>
        /// <param name="Flicker">ちらつきの有無</param>
        /// <param name="Trail">しだれの有無</param>
        /// <param name="ExplosionColors">咲いたときの色</param>
        /// <param name="FadeColors">散るときの色</param>
        public Firework(int LifeTime, byte FlightDuration, FireworksShapes Shape, bool Flicker, bool Trail, FireworksColors ExplosionColors, FireworksColors FadeColors)
        {
            this.LifeTime = LifeTime;
            this.FlightDuration = SetFlightDuration(FlightDuration);
            this.Shape = Shape;
            this.Flicker = Flicker;
            this.Trail = Trail;
            this.ExplosionColors = SetOneColor(ExplosionColors);
            this.FadeColors = SetOneColor(FadeColors);
        }

        /// <summary>
        /// 花火のインスタンスをつくります。
        /// </summary>
        /// <param name="LifeTime">花火が咲くまでの時間</param>
        /// <param name="FlightDuration">飛行時間</param>
        /// <param name="Shape">花火が咲いたときの形状</param>
        /// <param name="Flicker">ちらつきの有無</param>
        /// <param name="Trail">しだれの有無</param>
        /// <param name="ExplosionColors">咲いたときの色</param>
        /// <param name="FadeColors">散るときの色</param>
        public Firework(int LifeTime, byte FlightDuration, FireworksShapes Shape, bool Flicker, bool Trail, List<FireworksColors> ExplosionColors, FireworksColors FadeColors)
        {
            this.LifeTime = LifeTime;
            this.FlightDuration = SetFlightDuration(FlightDuration);
            this.Shape = Shape;
            this.Flicker = Flicker;
            this.Trail = Trail;
            this.ExplosionColors = ExplosionColors;
            this.FadeColors = SetOneColor(FadeColors);
        }

        /// <summary>
        /// 花火のインスタンスをつくります。
        /// </summary>
        /// <param name="LifeTime">花火が咲くまでの時間</param>
        /// <param name="FlightDuration">飛行時間</param>
        /// <param name="Shape">花火が咲いたときの形状</param>
        /// <param name="Flicker">ちらつきの有無</param>
        /// <param name="Trail">しだれの有無</param>
        /// <param name="ExplosionColors">咲いたときの色</param>
        /// <param name="FadeColors">散るときの色</param>
        public Firework(int LifeTime, byte FlightDuration, FireworksShapes Shape, bool Flicker, bool Trail, FireworksColors ExplosionColors, List<FireworksColors> FadeColors)
        {
            this.LifeTime = LifeTime;
            this.FlightDuration = SetFlightDuration(FlightDuration);
            this.Shape = Shape;
            this.Flicker = Flicker;
            this.Trail = Trail;
            this.ExplosionColors = SetOneColor(ExplosionColors);
            this.FadeColors = FadeColors;
        }

        private int SetFlightDuration(int FlightDuration)
        {
            if(FlightDuration > 3)
            {
                return 3;
            }
            else
            {
                return FlightDuration;
            }
        }

        private List<FireworksColors> SetOneColor(FireworksColors colors)
        {
            List<FireworksColors> color = new List<FireworksColors> { colors };
            return color;
        }

        private static string LifeTimeToString(Firework firework)
        {
            return firework.LifeTime.ToString();
        }

        private static string FlightDurationToString(Firework firework)
        {
            return firework.FlightDuration.ToString();
        }

        private static string ShapeToString(Firework firework)
        {
            switch (firework.Shape)
            {
                case FireworksShapes.SmallBall:
                    return "0";

                case FireworksShapes.LargeBall:
                    return "1";

                case FireworksShapes.Star:
                    return "2";

                case FireworksShapes.Creeper:
                    return "3";

                case FireworksShapes.Burst:
                    return "4";
                default:
                    return "0";
            }
        }

        private static string FlickerToString(Firework firework)
        {
            return firework.Flicker == true ? "1" : "0";
        }

        private static string TrailToString(Firework firework)
        {
            return firework.Trail == true ? "1" : "0";
        }

        private static string ExplosionColorsToString(Firework firework)
        {
            string returnColors = "";
            int Count = firework.ExplosionColors.Count;

            if (firework.ExplosionColors.Count > 1)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (Count == i + 1)
                    {
                        returnColors += ColorConvert(firework.ExplosionColors[i]);
                        break;
                    }
                    else
                    {
                        returnColors += ColorConvert(firework.ExplosionColors[i]) + ",";
                    }

                }
                return returnColors;
            }
            else
            {
                return ColorConvert(firework.ExplosionColors[0]);
            }
        }

        private static string FadeColorsToString(Firework firework)
        {
            string returnColors = "";
            int Count = firework.FadeColors.Count;

            if (firework.FadeColors.Count > 1)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (Count == i + 1)
                    {
                        returnColors += ColorConvert(firework.FadeColors[i]);
                        break;
                    }
                    else
                    {
                        returnColors += ColorConvert(firework.FadeColors[i]) + ",";
                    }

                }
                return returnColors;
            }
            else
            {
                return ColorConvert(firework.FadeColors[0]);
            }
        }

        private static string ColorConvert(FireworksColors color)
        {
            switch (color)
            {
                case FireworksColors.BLACK:
                    return "1973019";
                case FireworksColors.BLUE:
                    return "2437522";
                case FireworksColors.BROWN:
                    return "5320730";
                case FireworksColors.CYAN:
                    return "2651799";
                case FireworksColors.GRAY:
                    return "4408131";
                case FireworksColors.GREEN:
                    return "3887386";
                case FireworksColors.LIGHTBLUE:
                    return "6719955";
                case FireworksColors.LIGHTGRAY:
                    return "11250603";
                case FireworksColors.LIME:
                    return "4312372";
                case FireworksColors.MAGENTA:
                    return "12801229";
                case FireworksColors.ORANGE:
                    return "15435844";
                case FireworksColors.PINK:
                    return "14188952";
                case FireworksColors.PURPLE:
                    return "8073150";
                case FireworksColors.RED:
                    return "11743532";
                case FireworksColors.WHITE:
                    return "15790320";
                case FireworksColors.YELLOW:
                    return "14602026";
                default:
                    return "0";
            }
        }
        /// <summary>
        /// 花火を構成しているデータを取得します。
        /// </summary>
        /// <param name="firework">花火</param>
        public static string GetFireworkData(Firework firework)
        {
            string command = "{LifeTime:" + LifeTimeToString(firework) + ",FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:"
                + FlightDurationToString(firework) + ",Explosions:[{Type:" + ShapeToString(firework) + ",Flicker:" + FlickerToString(firework)
                + ",Trail:" + TrailToString(firework) + ",Colors:[I;" + ExplosionColorsToString(firework) + "],FadeColors:[I;" + FadeColorsToString(firework) + "]}]}}}}";
            Console.WriteLine(command);
            return command;
        }
    }
}
