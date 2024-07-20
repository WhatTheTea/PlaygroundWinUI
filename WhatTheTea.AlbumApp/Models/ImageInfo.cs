using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml.Media.Imaging;

using System;
using System.Threading.Tasks;

using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;

namespace WhatTheTea.AlbumApp.Models
{
    public class ImageInfo : ObservableObject
    {
        public StorageFile ImageFile { get; }

        public ImageProperties Properties { get; }

        public string ImageName { get; }

        public string ImageFileType { get; }

        public string ImageDimensions => $"{Properties.Width} x {Properties.Height}";

        public async Task<BitmapImage> GetImageAsync()
        {
            using IRandomAccessStream fileStream = await ImageFile.OpenReadAsync();

            // Create a bitmap to be the image source.
            BitmapImage bitmapImage = new();
            bitmapImage.SetSource(fileStream);

            return bitmapImage;
        }

        public async Task<BitmapImage> GetPreviewAsync() 
        {
            using StorageItemThumbnail thumbnail =
                await ImageFile.GetThumbnailAsync(ThumbnailMode.PicturesView);

            // Create a bitmap to be the image source.
            var bitmapImage = new BitmapImage();
            bitmapImage.SetSource(thumbnail);

            return bitmapImage;
        }

        public string ImageTitle
        {
            get => string.IsNullOrEmpty(Properties.Title) ? ImageName : Properties.Title;
            set
            {
                if (Properties.Title != value)
                {
                    Properties.Title = value;
                    _ = Properties.SavePropertiesAsync();

                    this.OnPropertyChanged();
                }
            }
        }

        public int ImageRating
        {
            get => (int)Properties.Rating;
            set
            {
                if (Properties.Rating != value)
                {
                    Properties.Rating = (uint)value;
                    _ = Properties.SavePropertiesAsync();

                    this.OnPropertyChanged();
                }
            }
        }

    }
}
