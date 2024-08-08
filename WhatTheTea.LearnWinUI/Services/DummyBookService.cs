using System;
using System.Collections.Generic;

using WhatTheTea.LearnWinUI.Contracts;
using WhatTheTea.LearnWinUI.Models;

namespace WhatTheTea.LearnWinUI.Services
{
    internal class DummyBookService : IBookService
    {
        public IEnumerable<Book> GetBooks() =>
        [
            new("Learn WinUI3", "A. Ashcraft", BookType.Digital, 2023),
            new("Clean Code", "R. Martin", BookType.Hardcover, 2024),
            new("A Philosophy of software design", "J. Ousterhout", BookType.Digital, 2021),
        ];
    }
}
