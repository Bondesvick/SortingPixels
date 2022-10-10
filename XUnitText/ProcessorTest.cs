using System.Windows.Media.Imaging;

namespace XUnitText
{
    public class ProcessorTest : IClassFixture<CatalogContextFactory>
    {
        public readonly IProcessPixels ProcessPixels;

        public ProcessorTest(CatalogContextFactory catalogContextFactory)
        {
            ProcessPixels = catalogContextFactory.ProcessPixels;
        }

        [Fact]
        public void Create_Random_BitmapSource_should_return_right_data()
        {
            byte[] pixels;

            var result = ProcessPixels.CreateRandomBitmapSource(200, 200, out pixels);

            result.ShouldNotBeNull();
            pixels.ShouldNotBeNull();
            pixels.Length.ShouldBeEquivalentTo(320000);
            _ = Assert.IsType<CachedBitmap>(result);
        }

        [Fact]
        public void Sort_Bitmap_Pixels_By_Hue_should_return_right_data()
        {
            var randomPixels = new byte[8 * 200 * 200];

            new Random().NextBytes(randomPixels);

            var result = ProcessPixels.SortBitmapPixelsByHue(randomPixels, 200, 200);

            result.ShouldNotBeNull();
            Assert.IsType<CachedBitmap>(result);
        }
    }
}