using System.Collections.Generic;

using WhatTheTea.LearnWinUI.Models;

namespace WhatTheTea.LearnWinUI.Contracts;

public interface IBookService
{
    IEnumerable<Book> GetBooks();
}
