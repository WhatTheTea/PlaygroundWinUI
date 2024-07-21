using System.Collections.ObjectModel;
using System.Threading;

using WhatTheTea.AlbumApp.Models;
using WhatTheTea.AlbumApp.Services;

namespace WhatTheTea.AlbumApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<ImageInfo> Images { get; } = [];

        public MainViewModel()
        {
            var uiContext = SynchronizationContext.Current;

            uiContext.Post(async (object state) =>
            {
                if (state is ObservableCollection<ImageInfo> images)
                {
                    await foreach (var image in ImageService.GetImagesAsync())
                    {
                        images.Add(image);
                    }
                }
            }, this.Images);
        }
    }
}
