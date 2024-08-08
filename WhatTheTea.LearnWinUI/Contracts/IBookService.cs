using System.Collections.Generic;

using WhatTheTea.LearnWinUI.Models;

namespace WhatTheTea.LearnWinUI.Contracts;

internal interface IBookService
{
    IEnumerable<Book> GetBooks();
}
