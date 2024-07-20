using System.Collections.ObjectModel;
using System.Linq;
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
            Task.Run(() => ImageService.GetImagesAsync()
                                             .ToBlockingEnumerable()
                                             .ToList()
                                             .ForEach(x => Images.Add(x)));
        }
    }
}
