using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftConnection.Entity
{
    public class FireworkRocket : IEntity
    {
        public string EntityName { get; private set; } = "firework_rocket";
        public int LifeTime { get; set; } = 0;
        public int Count { get; set; } = 1;
        public int FlightDuration { get; set; } = 2;
        public FireworkShape Shape { get; set; } = FireworkShape.SmallBall;
        public bool HasTwinkle { get; set; } = false;
        public bool HasTrail { get; set; } = false;
        public List<FireworkColor> Colors { get; set; } = new ();
        public List<FireworkColor> FadeColors { get; set; } = new ();
        public Motion Motion { get; set; } = new Motion (0, 0, 0);
        public bool IsEmpty { get; set; } = false;

        private string ToSnakeCase(FireworkShape shape)
        {
            return shape switch
            {
                FireworkShape.SmallBall => "small_ball",
                FireworkShape.LargeBall => "large_ball",
                FireworkShape.Creeper => "creeper",
                FireworkShape.Star => "star",
                _ => "burst"
            };
        }

        public string GetNBT()
        {
            if (IsEmpty)
            {
                return $"{{LifeTime:{LifeTime},Motion:{Motion}}}";
            }
            else
            {
                string explosions = $"{{shape:\"{ToSnakeCase(Shape)}\",has_twinkle:{(HasTwinkle ? 1 : 0)},has_trail:{(HasTrail ? 1 : 0)},colors:[I;{string.Join(",", Colors.Select(c => (int)c))}],fade_colors:[I;{string.Join(",", FadeColors.Select(c => (int)c))}]}}";
                return $"{{LifeTime:{LifeTime},FireworksItem:{{id:{EntityName},count:{Count},components:{{fireworks:{{flight_duration:{FlightDuration},explosions:[{explosions}]}}}}}},Motion:{Motion}}}";
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
