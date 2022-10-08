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

namespace SortingPixels.ViewModels
{
    public class PixelVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private BitmapSource _source;
        //= BitmapSource.Create(200, 200, 96d, 96d, PixelFormats.Bgra32, null, new byte[200 * 200],200);

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

        public PixelVM()
        {
            Source = CreateRandomBitmapSource(4, 4);
            Random = new Commands.Random(this);
            Sorting = new Commands.Sorting(this);
        }

        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void ColorSorting()
        {
            throw new NotImplementedException();
        }

        internal void RandomColor()
        {
            var newSourece = CreateRandomBitmapSource(250, 250);

            Source = newSourece;

            //Source = "https://res.cloudinary.com/bondesvick/image/upload/v1613518109/tsk9wvbkvzvwjrhhl5pp.jpg";
        }

        private BitmapSource CreateRandomBitmapSource(int width, int height)
        {
            var randomPixels = new byte[8 * width * height];

            new Random().NextBytes(randomPixels);

            //for (int y = 0; y < height; y++)
            //{
            //    int yIndex = y * width;
            //    for (int x = 0; x < width; x++)
            //    {
            //        randomPixels[x + yIndex] = (byte)(x + y);
            //    }
            //}

            var pixelColours = new List<System.Drawing.Color>();

            for (int i = 0; i < randomPixels.Length; i+=4)
            {
                    int R = randomPixels[i + 0];
                    int G = randomPixels[i + 1];
                    int B = randomPixels[i + 2];
                    int A = randomPixels[i + 3];

                    pixelColours.Add(System.Drawing.Color.FromArgb(A, R, G, B));
            }

            pixelColours = pixelColours.OrderBy(c => c.GetHue()).ToList();

            for (int i = 0; i < pixelColours.Count; i++)
            {
                int R = pixelColours[i].R;
                int G = pixelColours[i].G;
                int B = pixelColours[i].B;
                int A = pixelColours[i].A;

                randomPixels[i * 4 + 0] = (byte)R;
                randomPixels[i * 4 + 1] = (byte)G;
                randomPixels[i * 4 + 2] = (byte)B;
                randomPixels[i * 4 + 3] = (byte)A;
                
            }

            return BitmapSource.Create(width, height, 96d, 96d, PixelFormats.Bgra32, null, randomPixels, width * 8);
        }
    }
}
