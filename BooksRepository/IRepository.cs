﻿using System.Collections.Generic;
using BooksRepository.Models;

namespace BooksRepository
{
    public interface IBooksRepository
    {
        IEnumerable<AuthorAndTitle> GetAuthorsAndTitles();
        IEnumerable<AuthorAndISBN> GetAuthorsAndISBNs();
    }
}