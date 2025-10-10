using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Entities
{
    public class GeneralEntity : Entity
    {
        public string Id { get; }
        public Motion Motion { get; set; } = new();
        public string Nbt { get; set; }


        public GeneralEntity() { }

        public GeneralEntity(string id) 
        {
            Id = id;
        }
        
        public override string GetNbt() => Nbt;
    }
}
