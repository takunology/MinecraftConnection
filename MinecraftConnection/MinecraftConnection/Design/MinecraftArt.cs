using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp;

namespace MinecraftConnection.Design
{
    public class MinecraftArt
    {
        // コマンドに変換されたブロックリスト
        protected List<string> ImageBlockList = new List<string>();

        /// <summary>
        /// Minecraft に合わせたドット絵に変換します
        /// </summary>
        /// <param name="ImageSource">画像の場所</param>
        /// <param name="x">画像の大きさ水平方向</param>
        /// <param name="y">画像の大きさ垂直方向</param>
        
        public MinecraftArt(string ImageSource, int Horizontal, int Vertical)
        {
            Resize(ImageSource, Horizontal, Vertical);
        }

        private void Resize(string ImageSource, int x, int y)
        {
            var src = new Mat(ImageSource);
            var dst = new Mat();
            Cv2.Resize(src, dst, new Size(x, y), 0, 0, InterpolationFlags.Cubic);
            Cv2.ImShow("ResizeImage", dst);
            Cv2.WaitKey();
        }

        private void Convert()
        {

        }
    }
}
