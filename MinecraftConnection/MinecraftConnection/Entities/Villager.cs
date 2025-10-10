using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Entities
{
    public class Villager : Entity
    {
        public new string Id { get; set; } = "minecraft:villager";

        public string Profession { get; set; } = "";
        public int Level { get; set; }
        public bool IsBaby { get; set; }
        public Motion Motion { get; set; } = new();
        public string Nbt {  get; set; }

        public override string GetNbt() => Nbt;
    }
}
