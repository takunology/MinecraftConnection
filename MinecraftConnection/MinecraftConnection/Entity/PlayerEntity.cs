using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MinecraftConnection.RCON;

namespace MinecraftConnection.Entity
{
    public class PlayerEntity : EntityBase
    {
        
        public PlayerEntity(string playerName) : base(playerName)
        {
            GetPosition();
            GetRotation();
            GetMotion();
            GetFallDistance();
            GetFire();
            GetAir();
            GetOnGround();
            GetInvulnerable();
        }
    }
}
