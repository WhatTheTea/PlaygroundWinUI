using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.ApplicationModel;
using Windows.Storage.Search;
using Windows.Storage;
using WhatTheTea.AlbumApp.Models;

namespace WhatTheTea.AlbumApp.Services
{
    public static class ImageService
    {
        public async static IAsyncEnumerable<ImageInfo> GetImagesAsync()
        {
            StorageFolder picturesFolder = KnownFolders.PicturesLibrary;

            IReadOnlyList<StorageFile> imageFiles = await picturesFolder.GetFilesAsync();
            foreach (StorageFile file in imageFiles)
            {
                yield return await LoadImageInfoAsync(file);
            }
        }

        public async static Task<ImageInfo> LoadImageInfoAsync(StorageFile file)
        {
            var properties = await file.Properties.GetImagePropertiesAsync();
            ImageInfo info = new(properties,
                                     file, file.DisplayName, file.DisplayType);

            return info;
        }
    }
}
