using Processor;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SortingPixels.ViewModels
{
    public class PixelVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public BitmapSource? _source;

        public const int Width = 250;
        public const int Height = 250;
        public byte[] Pixels;

        public BitmapSource? Source
        {
            get { return _source; }
            set
            {
                _source = value;
                OnPropertyChanged(nameof(Source));
            }
        }

        public ICommand Random { get; }
        public ICommand Sorting { get; }
        public IProcessPixels _processPixels { get; }

        public PixelVM(IProcessPixels processPixels)
        {
            Random = new Commands.Random(this);
            Sorting = new Commands.Sorting(this);
            _processPixels = processPixels;
            Pixels = new byte[8 * Height * Width];
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RandomColor()
        {
            try
            {
                Source = _processPixels.CreateRandomBitmapSource(Width, Height, ref Pixels);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Check the Width and Height Values", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public void ColorSorting()
        {
            try
            {
                Source = _processPixels.SortBitmapPixelsByHue(Pixels, Width, Height);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Check the Width and Height Values", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}