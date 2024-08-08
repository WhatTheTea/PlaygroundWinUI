using System;
using System.Collections.Generic;

using WhatTheTea.LearnWinUI.Contracts;
using WhatTheTea.LearnWinUI.Models;

namespace WhatTheTea.LearnWinUI.Services
{
    internal class DummyBookService : IBookService
    {
        public IEnumerable<Book> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
