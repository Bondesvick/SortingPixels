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
                    int R = randomPixels[i + 0];
                    int G = randomPixels[i + 1];
                    int B = randomPixels[i + 2];
                    int A = randomPixels[i + 3];

                    pixelColours.Add(System.Drawing.Color.FromArgb(A, R, G, B));
                }

                pixelColours = pixelColours.OrderBy(c => c.GetHue()).ToList();

                for (int i = 0; i < pixelColours.Count; i++)
                {
                    int R = pixelColours[i].R;
                    int G = pixelColours[i].G;
                    int B = pixelColours[i].B;
                    int A = pixelColours[i].A;

                    randomPixels[i * 4 + 0] = (byte)R;
                    randomPixels[i * 4 + 1] = (byte)G;
                    randomPixels[i * 4 + 2] = (byte)B;
                    randomPixels[i * 4 + 3] = (byte)A;
                }

                var final = BitmapSource.Create(width, height, 96d, 96d, PixelFormats.Bgra32, null, randomPixels, width * 8);

                return final;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}