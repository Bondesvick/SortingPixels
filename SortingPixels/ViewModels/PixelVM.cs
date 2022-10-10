﻿using Processor;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SortingPixels.ViewModels
{
    public class PixelVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public BitmapSource? _source;

        public const int _width = 250;
        public const int _height = 250;
        public byte[] _pixels;

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
            _pixels = new byte[8 * _height * _width];
        }

        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RandomColor()
        {
            try
            {
                Source = _processPixels.CreateRandomBitmapSource(_width, _height, ref _pixels);
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
                Source = _processPixels.SortBitmapPixelsByHue(_pixels, _width, _height);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Check the Width and Height Values", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}