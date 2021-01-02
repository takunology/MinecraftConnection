using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.FireworkItems
{
    public class Firework
    {
        public string LifeTime { get; set; }
        public string FlightDuration { get; set; }
        public string Shape { get; set; }
        public string Flicker { get; set; }
        public string Trail { get; set; }
        public string ExplosionColors { get; set; }
        public string FadeColors { get; set; }

        public Firework(FireworkBase fireworkBase)
        {
            this.LifeTime = fireworkBase.LifeTime;
            this.FlightDuration = fireworkBase.FlightDuration;
            this.Shape = fireworkBase.Shape;
            this.Flicker = fireworkBase.Flicker;
            this.Trail = fireworkBase.Flicker;
            this.ExplosionColors = fireworkBase.ExplosionColors;
            this.FadeColors = fireworkBase.FadeColors;
        }
    }
}
