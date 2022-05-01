using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MinecraftConnection.Extends;

namespace MinecraftConnection.Entity
{
    public class EntityBase
    {
        public string EntityId { get; protected set; }
        public double PosX { get; protected set; }
        public double PosY { get; protected set; }
        public double PosZ { get; protected set; }
        public double RotationX { get; protected set; }
        public double RotationY { get; protected set; }
        public double MotionX { get; protected set; }
        public double MotionY { get; protected set; }
        public double MotionZ { get; protected set; }
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
            PosX = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Pos[0]").DataToDouble();
            PosY = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Pos[1]").DataToDouble();
            PosZ = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Pos[2]").DataToDouble();
        }

        public void GetRotation()
        {
            RotationX = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Rotation[0]").DataToDouble();
            RotationY = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Rotation[1]").DataToDouble();
        }

        public void GetMotion()
        {
            MotionX = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Motion[0]").DataToDouble();
            MotionY = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Motion[1]").DataToDouble();
            MotionZ = PublicRcon.Rcon.SendCommand($"data get entity {EntityId} Motion[2]").DataToDouble();
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

    }
}
