using System.Collections.Generic;
using System.Linq;
using Books;
using BooksRepository.Models;
using Author = BooksRepository.Models.Author;
using Title = BooksRepository.Models.Title;

namespace BooksRepository
{
    public class BooksRepository : IBooksRepository
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

        public bool Add(Author author, params Title[] titles)
        {
            try
            {
	            var authors = _dbContext.Authors;
	            var authorDb = new Books.Author
	            {
	                FirstName = author.FirstName,
	                LastName = author.LastName,
	                Titles = new List<Books.Title>()
	            };
	
	            foreach (var title in titles)
	            {
	                authorDb.Titles.Add(
	                    new Books.Title
	                    {
	                        Title1 = title.BookTitle,
	                        Copyright = title.Copyright,
	                        ISBN = title.ISBN,
	                        EditionNumber = title.EditionNumber
	                    });
	            }
	
	            authors.Add(authorDb);
	            _dbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }


            return true;
        }
        
    }
}