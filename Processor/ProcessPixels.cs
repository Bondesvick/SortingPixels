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

            if (randomPixels == null)
                return null;

            try
            {
                randomPixels = SortPixelsByHue(randomPixels);

                var generated = BitmapSource.Create(width, height, 96d, 96d, PixelFormats.Bgra32, null, randomPixels, width * 8);

                return RotateBitmap(generated, -90);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private byte[] SortPixelsByHue(byte[] pixels)
        {
            var pixelColours = new List<System.Drawing.Color>();

            for (int i = 0; i < pixels.Length; i += 4)
            {
                var R = pixels[i + 0];
                var G = pixels[i + 1];
                var B = pixels[i + 2];
                var A = pixels[i + 3];

                pixelColours.Add(System.Drawing.Color.FromArgb(A, R, G, B));
            }

            pixelColours = pixelColours.OrderBy(c => c.GetHue()).ToList();

            for (int i = 0; i < pixelColours.Count; i++)
            {
                var R = pixelColours[i].R;
                var G = pixelColours[i].G;
                var B = pixelColours[i].B;
                var A = pixelColours[i].A;

                pixels[i * 4 + 0] = R;
                pixels[i * 4 + 1] = G;
                pixels[i * 4 + 2] = B;
                pixels[i * 4 + 3] = A;
            }

            return pixels;
        }

        private BitmapSource RotateBitmap(BitmapSource bitmapSource, int angle)
        {
            TransformedBitmap transformedBitmap = new TransformedBitmap();

            transformedBitmap.BeginInit();
            transformedBitmap.Source = bitmapSource;
            RotateTransform rotateTransform = new RotateTransform(angle);
            transformedBitmap.Transform = rotateTransform;
            transformedBitmap.EndInit();

            return transformedBitmap;
        }
    }
}