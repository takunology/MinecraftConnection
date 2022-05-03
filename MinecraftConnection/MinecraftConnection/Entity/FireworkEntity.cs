using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Numerics;

namespace MinecraftConnection.Entity
{
    public class FireworkEntity : EntityBase
    {
        private string _id = "firework_rocket";
        private int _count = 1;

        public ushort LifeTime { get; set; } = 30;
        public int Flight { get; } = 2;
        public FireworkType Type { get; set; }
        public bool Flicker { get; set; }
        public bool Trail { get; set; }
        public List<FireworkColors> Colors { get; set; } = new List<FireworkColors>();
        public List<FireworkColors> FadeColors { get; set; } = new List<FireworkColors>();  

        private class FireworkNBT
        {
            [JsonPropertyName("LifeTime")]
            public ushort _LifeTime { get; set; }
            [JsonPropertyName("FireworksItem")]
            public FireworksItem _FireworksItem { get; set; }

            public class FireworksItem
            {
                [JsonPropertyName("id")]
                public string _Id { get; set; }
                [JsonPropertyName("Count")]
                public int _Count { get; set; }
                [JsonPropertyName("tag")]
                public Tag _Tag { get; set; }

                public class Tag
                {
                    [JsonPropertyName("Fireworks")]
                    public Fireworks _Fireworks { get; set; }

                    public class Fireworks
                    {
                        [JsonPropertyName("Flight")]
                        public int _Flight { get; set; }
                        [JsonPropertyName("Motion")]
                        public float[] _Motion { get; set; } = new float[3];
                        [JsonPropertyName("Explosions")]
                        public List<Explosions> _Explotions { get; set; } = new List<Explosions>();

                        public class Explosions
                        {
                            [JsonPropertyName("Type")]
                            public int _Type { get; set; }
                            [JsonPropertyName("Flicker")]
                            public bool _Flicker { get; set; }
                            [JsonPropertyName("Trail")]
                            public bool _Trail { get; set; }
                            [JsonPropertyName("Colors")]
                            public List<int> _Colors { get; set; } = new List<int>();
                            [JsonPropertyName("FadeColors")]
                            public List<int> _FadeColors { get; set; } = new List<int>();
                        }
                    }
                }
            }
        }

        public string GetNBT()
        {
            FireworkNBT fireworkNBT = new FireworkNBT()
            {
                _LifeTime = LifeTime,
                _FireworksItem = new FireworkNBT.FireworksItem()
                {
                    _Count = this._count,
                    _Id = this._id,
                    _Tag = new FireworkNBT.FireworksItem.Tag()
                    {
                        _Fireworks = new FireworkNBT.FireworksItem.Tag.Fireworks()
                        {
                            _Flight = Flight,
                            //_Motion = Motion,
                            _Explotions = new List<FireworkNBT.FireworksItem.Tag.Fireworks.Explosions>()
                            {
                                new FireworkNBT.FireworksItem.Tag.Fireworks.Explosions()
                                {
                                    _Type = (int)Type,
                                    _Flicker = Flicker,
                                    _Trail = Trail,
                                    _Colors = Colors.Select(x => (int)x).ToList(),
                                    _FadeColors = FadeColors.Select(x => (int)x).ToList(),
                                }
                            }
                        }
                    }
                }
            };

            string json = JsonSerializer.Serialize(fireworkNBT);
            json = json.Replace("true", "1");
            json = json.Replace("false", "0");
            json = json.Insert(json.IndexOf("\"Colors\":[") + 10, "I;");
            json = json.Insert(json.IndexOf("\"FadeColors\":[") + 14, "I;");
            return json;
        }
    }

    public enum FireworkType : int
    {
        SmallBall = 0,
        LargeBall = 1,
        Star = 2,
        Creeper = 3,
        Burst = 4
    }

    public enum FireworkColors : int
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
        WHITE = 15790320,
    }
}
