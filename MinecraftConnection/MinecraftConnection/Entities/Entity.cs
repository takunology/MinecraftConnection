using MinecraftConnection.Tools;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MinecraftConnection.Entities
{
    public abstract class Entity
    {
        public string? Id { get; }
        public Position Position { get; set; } = new Position();

        public abstract string GetNbt();
    }
}
