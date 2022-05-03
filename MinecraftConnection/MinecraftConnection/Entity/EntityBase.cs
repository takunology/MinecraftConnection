using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MinecraftConnection.Extends;

namespace MinecraftConnection.Entity
{
    public class EntityBase
    {
        public string EntityId { get; protected set; }
        public Position Postision { get; set; }
        public Rotation Rotation { get; set; }
        public Motion Motion { get; set; }
        public double FallDistance { get; protected set; }
        public short Fire { get; protected set; }
        public short Air { get; protected set; }
        public bool OnGround { get; protected set; }
        public bool Invulnerable { get; protected set; }
        public int PortalCooldown { get; protected set; }

        protected EntityBase() { }

        protected EntityBase(string entityId)
        {
            EntityId = entityId;
        }

        public void GetPosition()
        {     
            double posX = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Pos[0]").DataToDouble();
            double posY = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Pos[1]").DataToDouble();
            double posZ = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Pos[2]").DataToDouble();
            this.Postision = new Position(posX, posY, posZ);
        }

        public void GetRotation()
        {
            double rotX = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Rotation[0]").DataToDouble();
            double rotY = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Rotation[1]").DataToDouble();
            this.Rotation = new Rotation(rotX, rotY);
        }

        public void GetMotion()
        {
            double motX = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Motion[0]").DataToDouble();
            double motY = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Motion[1]").DataToDouble();
            double motZ = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Motion[2]").DataToDouble();
            this.Motion = new Motion(motX, motY, motZ);
        }

        public void GetFallDistance()
        {
            FallDistance = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} FallDistance").DataToDouble();
        }

        public void GetFire()
        {
            Fire = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Fire").DataToShort();
        }

        public void GetAir()
        {
            Air = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Air").DataToShort();
        }

        public void GetOnGround()
        {
            OnGround = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} OnGround").DataToBool();
        }

        public void GetInvulnerable()
        {
            Invulnerable = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Invulnerable").DataToBool();
        }
        
        public void GetPortalCooldown()
        {
            PortalCooldown = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Invulnerable").DataToInt();
        }

        protected void MotionToNBT()
        {

        }

    }

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
}
