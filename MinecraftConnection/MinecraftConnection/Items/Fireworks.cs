using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Items
{
    /// <summary>
    /// 花火を作るためのクラスです。
    /// </summary>
    public partial class Fireworks
    {
        public int LifeTime { get; set; }
        public int FlightDuration { get; set; }
        public FireworksShapes Shape { get; set; }
        public bool Flicker { get; set; }
        public bool Trail { get; set; }
        public List<FireworksColors> ExplosionColors { get; set; }
        public List<FireworksColors> FadeColors { get; set; }

        /// <summary>
        /// 花火をつくります。
        /// </summary>
        /// <param name="LifeTime">花火が咲くまでの時間</param>
        /// <param name="FlightDuration">飛行距離(1～3段階)</param>
        /// <param name="Shape">花火が咲いたときの形状</param>
        /// <param name="Flicker">きらめきの有無</param>
        /// <param name="Trail">流星の有無</param>
        /// <param name="ExplosionColors">咲いたときの色</param>
        /// <param name="FadeColors">散るときの色</param>
        public Fireworks(int LifeTime, byte FlightDuration, FireworksShapes Shape, bool Flicker, bool Trail, List<FireworksColors> ExplosionColors, List<FireworksColors> FadeColors)
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
        /// 花火をつくります。
        /// </summary>
        /// <param name="LifeTime">花火が咲くまでの時間</param>
        /// <param name="FlightDuration">飛行距離(1～3段階)</param>
        /// <param name="Shape">花火が咲いたときの形状</param>
        /// <param name="Flicker">きらめきの有無</param>
        /// <param name="Trail">流星の有無</param>
        /// <param name="ExplosionColors">咲いたときの色（単色）</param>
        /// <param name="FadeColors">散るときの色（単色）</param>
        public Fireworks(int LifeTime, byte FlightDuration, FireworksShapes Shape, bool Flicker, bool Trail, FireworksColors ExplosionColors, FireworksColors FadeColors)
        {
            this.LifeTime = LifeTime;
            this.FlightDuration = SetFlightDuration(FlightDuration);
            this.Shape = Shape;
            this.Flicker = Flicker;
            this.Trail = Trail;
            this.ExplosionColors = SetColor(ExplosionColors);
            this.FadeColors = SetColor(FadeColors);
        }
        /// <summary>
        /// 花火をつくります。
        /// </summary>
        /// <param name="LifeTime">花火が咲くまでの時間</param>
        /// <param name="FlightDuration">飛行距離(1～3段階)</param>
        /// <param name="Shape">花火が咲いたときの形状</param>
        /// <param name="Flicker">きらめきの有無</param>
        /// <param name="Trail">流星の有無</param>
        /// <param name="ExplosionColors">咲いたときの色（単色）</param>
        /// <param name="FadeColors">散るときの色</param>
        public Fireworks(int LifeTime, byte FlightDuration, FireworksShapes Shape, bool Flicker, bool Trail, FireworksColors ExplosionColors, List<FireworksColors> FadeColors)
        {
            this.LifeTime = LifeTime;
            this.FlightDuration = SetFlightDuration(FlightDuration);
            this.Shape = Shape;
            this.Flicker = Flicker;
            this.Trail = Trail;
            this.ExplosionColors = SetColor(ExplosionColors);
            this.FadeColors = FadeColors;
        }
        /// <summary>
        /// 花火をつくります。
        /// </summary>
        /// <param name="LifeTime">花火が咲くまでの時間</param>
        /// <param name="FlightDuration">飛行距離(1～3段階)</param>
        /// <param name="Shape">花火が咲いたときの形状</param>
        /// <param name="Flicker">きらめきの有無</param>
        /// <param name="Trail">流星の有無</param>
        /// <param name="ExplosionColors">咲いたときの色</param>
        /// <param name="FadeColors">散るときの色（単色）</param>
        public Fireworks(int LifeTime, byte FlightDuration, FireworksShapes Shape, bool Flicker, bool Trail, List<FireworksColors> ExplosionColors, FireworksColors FadeColors)
        {
            this.LifeTime = LifeTime;
            this.FlightDuration = SetFlightDuration(FlightDuration);
            this.Shape = Shape;
            this.Flicker = Flicker;
            this.Trail = Trail;
            this.ExplosionColors = ExplosionColors;
            this.FadeColors = SetColor(FadeColors);
        }
        
        private int SetFlightDuration(int FlightDuration)
        {
            if (FlightDuration == 0) return 1;
            else if (FlightDuration > 3) return 3;
            else return FlightDuration;
        }
        private List<FireworksColors> SetColor(FireworksColors Color)
        {
            List<FireworksColors> Colors = new List<FireworksColors> { Color };
            return Colors;
        }
    }

    public enum FireworksShapes
    {
        SmallBall,
        LargeBall,
        Star,
        Creeper,
        Burst
    }

    public enum FireworksColors : int
    {
        BLACK = 1973019,
        RED = 11743532,
        GREEN = 3887386,
        BROWN = 5320730,
        BLUE = 2437522,
        PURPLE = 8073150,
        CYAN = 2651799,
        LIGHTGRAY = 11250603,
        GRAY = 4408131,
        PINK = 14188952,
        LIME = 4312372,
        YELLOW = 14602026,
        LIGHTBLUE = 6719955,
        MAGENTA = 12801229,
        ORANGE = 15435844,
        WHITE = 15790320
    }
}
