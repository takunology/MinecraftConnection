using System.Collections.Generic;

namespace MinecraftConnection
{
    public struct Position(double x, double y, double z)
    {
        public readonly double X = x;
        public readonly double Y = y;
        public readonly double Z = z;
    }

    public struct Rotation(double x, double y)
    {
        public readonly double X = x;
        public readonly double Y = y;
    }

    public struct Motion(double x, double y, double z)
    {
        public readonly double X = x;
        public readonly double Y = y;
        public readonly double Z = z;
    }

    public struct ItemStack(int slot, string id, int count)
    {
        public readonly int Slot = slot;
        public readonly string Id = id;
        public readonly int Count = count;

        public Dictionary<string, object?> ToNbt()
        {
            return new Dictionary<string, object?>
            {
                { "slot", Slot },
                { "id", Id },
                { "count", Count }
            };
        }
    }
}
