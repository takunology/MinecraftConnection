using MinecraftConnection.Entity.Base;

namespace MinecraftConnection.Entity
{
    public class Player : LivingEntityBase
    {
        
        public Player(string playerName) : base(playerName)
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
