using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Entities
{
    public class Player : Entity
    {
        public new string Id { get; set; } = "minecraft:player";

        public string Name { get; set; } = "";
        public double Health { get; set; }
        public List<ItemStack> Inventory { get; set; } = new();
        public Motion Motion { get; set; } = new();
        public string Nbt { get; set; }

        public override string GetNbt() => Nbt;
    }
}
