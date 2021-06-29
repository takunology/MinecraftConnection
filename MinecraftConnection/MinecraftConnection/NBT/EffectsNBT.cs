using MinecraftConnection.Data;
using MinecraftConnection.Items;

namespace MinecraftConnection.NBT
{
    public static class EffectsNBT
    {
        public static string ToNBT(this Potion Potion)
        {
            string NBT;

            if (Potion.Long == true)
                NBT = "{Potion:\"" + "long_" + Potion.Effect.GetMinecraftID() + "\"}";
            else if (Potion.Strong == true)
                NBT = "{Potion:\"" + "strong_" + Potion.Effect.GetMinecraftID() + "\"}";
            else
                NBT = "{Potion:\"" + Potion.Effect.GetMinecraftID() + "\"}";

            return NBT;
        }
    }
}