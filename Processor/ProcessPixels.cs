using Processor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Processor
{
    public class ProcessPixels : IProcessPixels
    {
        /// <summary>
        /// Generates a BItmapSource from a randon byte array
        /// </summary>
        /// <param name="width">image width</param>
        /// <param name="height">image height</param>
        /// <param name="pixels">pixel byte array, randomly generated</param>
        /// <returns>Generated BitmapSource Image</returns>
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

        /// <summary>
        /// Sorts Pixel byte array by Hue
        /// </summary>
        /// <param name="randomPixels">pixel byte array to be sorted</param>
        /// <param name="width">image width</param>
        /// <param name="height">image height</param>
        /// <returns>Generated BitmapSource Image</returns>
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
            var pixelColours = new List<RGBA>();

            for (int i = 0; i < pixels.Length; i += 4)
            {
                var rgba = new RGBA(pixels, i);

                pixelColours.Add(rgba);
            }

            pixelColours = pixelColours.OrderBy(c => c.GetHue()).ToList();

            for (int i = 0; i < pixelColours.Count; i++)
            {
                pixelColours[i].AssignRGBAToPixel(pixels, i);
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