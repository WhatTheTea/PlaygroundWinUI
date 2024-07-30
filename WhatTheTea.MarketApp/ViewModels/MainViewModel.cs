using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

using WhatTheTea.MarketApp.Data;
using WhatTheTea.MarketApp.Models;

namespace WhatTheTea.MarketApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly MarketContext _marketContext = new();

        public ObservableCollection<Product> Products { get; set; } = new();

        public MainViewModel()
        {
            var dataSet = _marketContext.Products;

            this.Products.Concat(dataSet.OrderBy(x => x.Title))
                .ToList()
                .ForEach(this.Products.Add);
        }

        [RelayCommand]
        private void AddProduct() 
        {
            var product = new Product
            {
                Title = "Hello",
                Description = "World",
                Price = 1337
            };
            this.Products.Clear();
            _marketContext.Products.Add(product);
            _marketContext.SaveChanges();

            this.Products.Concat(_marketContext.Products.OrderBy(x => x.Title))
                .ToList()
                .ForEach(this.Products.Add);
        }

        [RelayCommand]
        private void DropDatabaseLol() 
        {
            _marketContext.RemoveRange(_marketContext.Products);
        }
    }
}
