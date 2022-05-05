using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection
{
    public struct Position
    {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        public Position(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    public struct Rotation
    {
        public readonly double X;
        public readonly double Y;

        public Rotation(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public struct Motion
    {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        public Motion(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    public struct ItemStack
    {
        public readonly ushort Slot;
        public readonly string Id;
        public readonly ushort Count;

        public ItemStack(ushort slot, string id, ushort count)
        {
            this.Id = id;
            this.Slot = slot;
            this.Count = count;
        }
    }
}
