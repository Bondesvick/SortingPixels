using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Processor
{
    public class ProcessPixels : IProcessPixels
    {
        public BitmapSource CreateRandomBitmapSource(int width, int height, ref byte[] pixels)
        {
            try
            {
                var randomPixels = new byte[8 * width * height];

                new Random().NextBytes(randomPixels);

                pixels = randomPixels;

                return BitmapSource.Create(width, height, 96d, 96d, PixelFormats.Bgra32, null, randomPixels, width * 8);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BitmapSource? SortBitmapPixelsByHue(byte[] randomPixels, int width, int height)
        {
            var pixelColours = new List<System.Drawing.Color>();

            if (randomPixels == null)
                return null;

            try
            {
                for (int i = 0; i < randomPixels.Length; i += 4)
                {
                    var R = randomPixels[i + 0];
                    var G = randomPixels[i + 1];
                    var B = randomPixels[i + 2];
                    var A = randomPixels[i + 3];

                    pixelColours.Add(System.Drawing.Color.FromArgb(A, R, G, B));
                }

                pixelColours = pixelColours.OrderBy(c => c.GetHue()).ToList();

                for (int i = 0; i < pixelColours.Count; i++)
                {
                    var R = pixelColours[i].R;
                    var G = pixelColours[i].G;
                    var B = pixelColours[i].B;
                    var A = pixelColours[i].A;

                    randomPixels[i * 4 + 0] = R;
                    randomPixels[i * 4 + 1] = G;
                    randomPixels[i * 4 + 2] = B;
                    randomPixels[i * 4 + 3] = A;
                }

                var generated = BitmapSource.Create(width, height, 96d, 96d, PixelFormats.Bgra32, null, randomPixels, width * 8);

                TransformedBitmap transformedBitmap = new TransformedBitmap();

                transformedBitmap.BeginInit();
                transformedBitmap.Source = generated;
                RotateTransform rotateTransform = new RotateTransform(-90);
                transformedBitmap.Transform = rotateTransform;
                transformedBitmap.EndInit();

                return transformedBitmap;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}