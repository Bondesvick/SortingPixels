using System;
using SortingPixels.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SortingPixels.ViewModels
{
    public class PixelVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _source = "";

        public string Source
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
            throw new NotImplementedException();
        }
    }
}
