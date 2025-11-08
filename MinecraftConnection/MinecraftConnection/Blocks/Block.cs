using MinecraftConnection.Tools;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MinecraftConnection.Blocks
{
    public class Block : IBlock
    {
        public string Id { get; set; }
        public Position Position { get; set; } = new ();
        public List<ItemStack> Items { get; set; } = [];
    }

    
}
