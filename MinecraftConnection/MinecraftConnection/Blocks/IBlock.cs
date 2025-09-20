using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Blocks
{
    public interface IBlock
    {
        Position Position { get; }
        string Id { get; }
    }
}
