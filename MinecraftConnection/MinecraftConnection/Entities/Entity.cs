using MinecraftConnection.Tools;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MinecraftConnection.Entities
{
    public abstract class Entity
    {
        public abstract string Id { get; }
        public Position Position { get; set; } = new Position();
        public Motion Motion { get; set; } = new Motion();

        public abstract string GetNbt();
    }
}
