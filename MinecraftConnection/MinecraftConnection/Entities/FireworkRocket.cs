using MinecraftConnection.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftConnection.Entities
{
    public class FireworkRocket : Entity
    {
        public override string Id  => "firework_rocket";
        public int LifeTime { get; set; } = 0;
        public int Count { get; set; } = 1;
        public int FlightDuration { get; set; } = 2;
        public FireworkShape Shape { get; set; } = FireworkShape.SmallBall;
        public bool HasTwinkle { get; set; } = false;
        public bool HasTrail { get; set; } = false;
        public List<FireworkColor> Colors { get; set; } = new ();
        public List<FireworkColor> FadeColors { get; set; } = new ();
        public bool IsEmpty { get; set; } = false;

        public override string GetNbt()
        {
            if (IsEmpty)
            {
                return NbtSerializer.Serialize(new Dictionary<string, object?>
                {
                    { "LifeTime", LifeTime },
                    { "Motion", Motion }
                });
            }
            else
            {
                var explosion = new Dictionary<string, object?>
                {
                    { "shape", NbtSerializer.ToSnakeCase(Shape) },
                    { "has_twinkle", NbtSerializer.BoolToInt(HasTwinkle) },
                    { "has_trail", NbtSerializer.BoolToInt(HasTrail) },
                    { "colors", NbtSerializer.ToColorArray(Colors) },
                    { "fade_colors", NbtSerializer.ToColorArray(FadeColors) }
                };

                var fireworks = new Dictionary<string, object?>
                {
                    { "flight_duration", FlightDuration },
                    { "explosions", new List<Dictionary<string, object?>> { explosion } }
                };

                var item = new Dictionary<string, object?>
                {
                    { "id", Id },
                    { "count", Count },
                    { "components", new Dictionary<string, object?> { { "fireworks", fireworks } } }
                };

                return NbtSerializer.Serialize(new Dictionary<string, object?>
                {
                    { "LifeTime", LifeTime },
                    { "FireworksItem", item },
                    { "Motion", Motion }
                });
            }
        }
    }

    public static class FireworkOption
    {
        private static readonly Random _random = new();
        public static List<FireworkColor> GetRandomColors(int count = 1)
        {
            var colors = Enum.GetValues(typeof(FireworkColor)).Cast<FireworkColor>().ToList();
            var result = new List<FireworkColor>();

            for (int i = 0; i < count; i++)
            {
                var index = _random.Next(colors.Count);
                result.Add(colors[index]);
            }

            return result;
        }

        public static FireworkShape GetRandomShape()
        {
            var shapes = Enum.GetValues(typeof(FireworkShape)).Cast<FireworkShape>().ToList();
            int idx = _random.Next(shapes.Count);
            return shapes[idx];
        }
    }

    public enum FireworkColor : int
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

    public enum FireworkShape
    {
        SmallBall,
        LargeBall,
        Star,
        Creeper,
        Burst
    }
}
