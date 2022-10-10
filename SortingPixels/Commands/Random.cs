using SortingPixels.ViewModels;

namespace SortingPixels.Commands
{
    public class Random : CommandBase
    {
        public PixelVM PixelVM { get; }

        public Random(PixelVM pixelVM)
        {
            PixelVM = pixelVM;
        }

        public override void Execute(object? parameter)
        {
            PixelVM.RandomColor();
        }
    }
}