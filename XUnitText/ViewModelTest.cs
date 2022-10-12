using SortingPixels.ViewModels;

namespace XUnitText
{
    public class ViewModelTest : IClassFixture<CatalogContextFactory>
    {
        public readonly IProcessPixels ProcessPixels;

        public ViewModelTest(CatalogContextFactory catalogContextFactory)
        {
            ProcessPixels = catalogContextFactory.ProcessPixels;
        }

        [Fact]
        public void Create_Random_BitmapSource_should_work_as_expected()
        {
            var vm = new PixelVM(ProcessPixels);
            vm.RandomColor();

            vm.Pixels.ShouldNotBeNull();
            Assert.True(vm.Pixels.Length > 4);
            vm.Source.ShouldNotBeNull();
        }

        [Fact]
        public void Sort_Bitmap_Pixels_By_Hue_should_work_as_expected()
        {
            var vm = new PixelVM(ProcessPixels);
            vm.Pixels = new byte[8 * 250 * 250];

            vm.ColorSorting();

            vm.Source.ShouldNotBeNull();
        }
    }
}