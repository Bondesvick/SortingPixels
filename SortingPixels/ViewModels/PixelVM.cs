using System;
using SortingPixels.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Random = System.Random;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection.Metadata;
using System.Windows.Controls;
using Processor;

namespace SortingPixels.ViewModels
{
    public class PixelVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private BitmapSource _source;

        private byte[] _pixels;
        private const int _width = 250;
        private const int _height = 200;

        public BitmapSource Source
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

            Source = _processPixels.CreateRandomBitmapSource(width: 2, 2, out _pixels);
        }

        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void RandomColor()
        {
            try
            {
                Source = _processPixels.CreateRandomBitmapSource(_width, _height, out _pixels);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Check the Width and Height Values",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            
        } 

        internal void ColorSorting()
        {
            try
            {
                Source = _processPixels.SortBitmapPixelsByHue(_pixels, _width, _height);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Check the Width and Height Values",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
        }
    }
}
