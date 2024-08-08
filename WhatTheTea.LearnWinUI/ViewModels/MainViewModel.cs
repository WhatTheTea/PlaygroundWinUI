using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections.ObjectModel;

using WhatTheTea.LearnWinUI.Contracts;
using WhatTheTea.LearnWinUI.Models;

namespace WhatTheTea.LearnWinUI.ViewModels
{
    internal partial class MainViewModel(IBookService bookService) : ObservableObject
    {
        public ObservableCollection<Book> books = [..bookService.GetBooks()];

        [ObservableProperty]
        private Book? selectedBook;
    }
}
