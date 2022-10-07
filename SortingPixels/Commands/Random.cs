using SortingPixels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
