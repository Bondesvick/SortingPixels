using System.Windows.Media.Imaging;

namespace Processor
{
    public interface IProcessPixels
    {
        BitmapSource CreateRandomBitmapSource(int width, int height, ref byte[] pixels);

        BitmapSource? SortBitmapPixelsByHue(byte[] randomPixels, int width, int height);
    }
}