using System.Collections.Generic;
using System.Linq;
using Books;
using BooksRepository.Models;

namespace BooksRepository
{
    public class BooksRepo : IBooksRepository
    {
        private readonly BooksEntities _dbContext = new BooksEntities();


        public IEnumerable<AuthorAndTitle> GetAuthorsAndTitles()
        {
            return
                from book in _dbContext.Titles
                from author in book.Authors
                orderby author.LastName, author.FirstName, book.Title1
                select new AuthorAndTitle
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Title = book.Title1
                };
        }

        public IEnumerable<AuthorAndISBN> GetAuthorsAndISBNs()
        {
            return
                from author in _dbContext.Authors
                from title in author.Titles
                orderby author.LastName, author.FirstName
                select new AuthorAndISBN
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    ISBN = title.ISBN
                };
        }
    }
}