using SortingPixels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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
        public void Create_Random_BitmapSource_should_work_as_expeced()
        {

            var vm = new PixelVM(ProcessPixels);
            vm.RandomColor();

            vm._pixels.ShouldNotBeNull();
            Assert.True(vm._pixels.Length > 1);
            vm.Source.ShouldNotBeNull();
        }

        [Fact]
        public void Sort_Bitmap_Pixels_By_Hue_should_work_as_expeced()
        {
            var vm = new PixelVM(ProcessPixels);
            vm.ColorSorting();

            vm.Source.ShouldNotBeNull();
        }
    }
}
