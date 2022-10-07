using SortingPixels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
