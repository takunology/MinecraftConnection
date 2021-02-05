using System;
using MinecraftConnection.Design;

namespace ExampleImageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ImSource = @"C:\Users\takun\Desktop\IMG_6235.JPG";
            //var ImSource = @"C:\Users\takun\OneDrive\画像\スクリーンショット\ホロライブ\2021-01-01 (9).png";
            MinecraftArt minecraftArt = new MinecraftArt(ImSource, 256, 128);
        }
    }
}
