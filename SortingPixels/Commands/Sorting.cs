using SortingPixels.ViewModels;

namespace SortingPixels.Commands
{
    public class Sorting : CommandBase
    {
        public PixelVM PixelVM { get; }

        public Sorting(PixelVM pixelVM)
        {
            PixelVM = pixelVM;
        }

        public override void Execute(object? parameter)
        {
            PixelVM.ColorSorting();
        }
    }
}