using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Fireworks
{
    public class FireworksBase
    {
        public static string PosX { get; set; }
        public static string PosY { get; set; }
        public static string PosZ { get; set; }
        public static string LifeTime { get; set; }
        public static string FlightDuration { get; set; }
        public static string Shape { get; set; }
        public static string Flicker { get; set; }
        public static string Trail { get; set; }
        public static string ExplosionColors { get; set; }
        public static string FadeColors { get; set; }

        public static void IsFlicker(bool torf)
        {
            Flicker = (torf == true) ? "1" : "0";
        }

        public static void IsTrail(bool torf)
        {
            Trail = (torf == true) ? "1" : "0";
        }
    }
}
