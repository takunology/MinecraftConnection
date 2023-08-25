using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Extends
{
    public class PlaySound
    {
        private string _sound;

        public PlaySound(Sound sound) 
        {
            _sound = sound switch
            {
                Sound.Banjo => "block.note_block.banjo",
                Sound.BaseDrum => "block.note_block.basedrum",
                Sound.Bass => "block.note_block.bass",
                Sound.Bell => "block.note_block.bell",
                Sound.Bit => "block.note_block.bit",
                Sound.Chime => "block.note_block.basedrum",
                Sound.CowBell => "block.note_block.cow_bell",
                Sound.DidGeridoo => "block.note_block.didgeridoo",
                Sound.Flute => "block.note_block.flute",
                Sound.Guiter => "block.note_block.guiter",
                Sound.Harp => "block.note_block.harp",
                Sound.Hat => "block.note_block.hat",
                Sound.IronXylophone => "block.note_block.iron_xylophone",
                Sound.Pling => "block.note_block.pling",
                Sound.Snare => "block.note_block.snare",
                Sound.Xylophone => "block.note_block.xylophone",
                _ => ""
            };
        }

        public string MakeCommand()
        {
            var command = $"execute as @p at @s run playsound {_sound} master @a ~ ~ ~ 1";
            return command;
        }

        public string MakeCommand(double pitch)
        {
            var command = $"execute as @p at @s run playsound {_sound} master @a ~ ~ ~ 1 {pitch}";
            return command;
        }
    }

    public enum Sound
    {
        Banjo,
        BaseDrum,
        Bass,
        Bell,
        Bit,
        Chime,
        CowBell,
        DidGeridoo,
        Flute,
        Guiter,
        Harp,
        Hat,
        IronXylophone,
        Pling,
        Snare,
        Xylophone
    }
}
