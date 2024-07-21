using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using WhatTheTea.AlbumApp.Models;
using WhatTheTea.AlbumApp.Services;

namespace WhatTheTea.AlbumApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<ImageInfo> Images { get; } = [];

        public MainViewModel()
        {
            // GetAwaiter.GetResult in this case will be faster solution
            // context usage here might be an overhead :)
            var uiContext = SynchronizationContext.Current;
     
            uiContext.Post(async (object state) =>
            {
                if (state is ObservableCollection<ImageInfo> images)
                {
                    var newImages = await Task.Run(async () => await ImageService.GetImagesAsync().ToArrayAsync());
                    foreach (var image in newImages)
                    {
                        images.Add(image);
                    }
                }
            }, this.Images);
        }
    }
}
