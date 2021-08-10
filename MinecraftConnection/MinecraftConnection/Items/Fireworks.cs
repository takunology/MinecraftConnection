using System;
using System.Collections.Generic;

namespace MinecraftConnection.Items
{
    /// <summary>
    /// 花火を作るためのクラスです。
    /// </summary>
    public class Fireworks
    {
        public int LifeTime = 0;
        public FireworksShapes Shape;
        public bool Flicker;
        public bool Trail;
        public List<FireworksColors> ExplosionColors;
        public List<FireworksColors> FadeColors;
        public double MotionX = 0.0;
        public double MotionY = 0.0;
        public double MotionZ = 0.0;
        /// <summary>
        /// 花火をつくります。
        /// </summary>
        public Fireworks(int LifeTime, FireworksShapes Shape, FireworksColors ExplosionColors, FireworksColors FadeColors)
        {
            this.LifeTime = LifeTime;
            this.Shape = Shape;
            this.ExplosionColors = SetColor(ExplosionColors);
            this.FadeColors = SetColor(FadeColors);
        }
        /// <summary>
        /// 花火をつくります。
        /// </summary>
        public Fireworks(int LifeTime, FireworksShapes Shape, List<FireworksColors> ExplosionColors, List<FireworksColors> FadeColors)
        {
            this.LifeTime = LifeTime;
            this.Shape = Shape;
            this.ExplosionColors = ExplosionColors;
            this.FadeColors = FadeColors;
        }
        /// <summary>
        /// 花火をつくります。
        /// </summary>
        public Fireworks(int LifeTime, FireworksShapes Shape, FireworksColors ExplosionColors, List<FireworksColors> FadeColors)
        {
            this.LifeTime = LifeTime;
            this.Shape = Shape;
            this.ExplosionColors = SetColor(ExplosionColors);
            this.FadeColors = FadeColors;
        }
        /// <summary>
        /// 花火をつくります。
        /// </summary>
        public Fireworks(int LifeTime, FireworksShapes Shape, List<FireworksColors> ExplosionColors, FireworksColors FadeColors)
        {
            this.LifeTime = LifeTime;
            this.Shape = Shape;
            this.ExplosionColors = ExplosionColors;
            this.FadeColors = SetColor(FadeColors);
        }

        //もしかしたらいらないかも？
        private List<FireworksColors> SetColor(FireworksColors Color)
        {
            List<FireworksColors> Colors = new List<FireworksColors> { Color };
            return Colors;
        }
    }

    public enum FireworksShapes : int
    {
        SmallBall = 0,
        LargeBall = 1,
        Star = 2,
        Creeper = 3,
        Burst = 4
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
