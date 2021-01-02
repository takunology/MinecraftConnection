using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.FireworkItems
{
    public class Firework
    {
        public int LifeTime { get; private set; }
        public int FlightDuration { get; private set; }
        public FireworkShapes Shape { get; private set; }
        public bool Flicker { get; private set; }
        public bool Trail { get; private set; }
        public List<MCColors> ExplosionColors { get; private set; }
        public List<MCColors> FadeColors { get; private set; }

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
        public Firework(int LifeTime, byte FlightDuration, FireworkShapes Shape, bool Flicker, bool Trail, List<MCColors> ExplosionColors, List<MCColors> FadeColors)
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
        public Firework(int LifeTime, byte FlightDuration, FireworkShapes Shape, bool Flicker, bool Trail, MCColors ExplosionColors, MCColors FadeColors)
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
        public Firework(int LifeTime, byte FlightDuration, FireworkShapes Shape, bool Flicker, bool Trail, List<MCColors> ExplosionColors, MCColors FadeColors)
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
        public Firework(int LifeTime, byte FlightDuration, FireworkShapes Shape, bool Flicker, bool Trail, MCColors ExplosionColors, List<MCColors> FadeColors)
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

        private List<MCColors> SetOneColor(MCColors colors)
        {
            List<MCColors> color = new List<MCColors> { colors };
            return color;
        }
    }
}
