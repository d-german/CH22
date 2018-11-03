using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Books;

namespace DisplayBooks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new BooksEntities())
            {
                var authors = db.Authors;

                authors.Add(new Author
                {
                    FirstName = "Damon",
                    LastName = "German",
                    Titles = new List<Title>
                    {
                        new Title
                        {
                            Title1 = "Hello World",
                            Copyright = "2018",
                            EditionNumber = 1,
                            ISBN = "552122222"
                        }
                    }
                });

                foreach (var author in authors)
                {
                    author.FirstName = author.FirstName.ToUpper();
                    author.LastName = author.LastName.ToUpper();
                }

                db.SaveChanges();

                DisplayAuthorsAndISBNs(db);
                DisplayAuthorsAndTitles(db);
            }
        }

        private static void DisplayAuthorsAndTitles(BooksEntities db)
        {
            var authorsAndTitles =
                from book in db.Titles
                from author in book.Authors
                orderby author.LastName, author.FirstName, book.Title1
                select new {author.FirstName, author.LastName, book.Title1};

            var buf = new StringBuilder();

            // display authors and titles in tabular format
            foreach (var element in authorsAndTitles)
                buf.Append($"\r\n\t{element.FirstName,-10} " +
                           $"{element.LastName,-10} {element.Title1}");

            Console.WriteLine(buf.ToString());
        }

        private static void DisplayAuthorsAndISBNs(BooksEntities db)
        {
            var authorsAndISBNs =
                from author in db.Authors
                from title in author.Titles
                orderby author.LastName, author.FirstName
                select new {author.FirstName, author.LastName, title.ISBN};

            var buf = new StringBuilder();

            // display authors and ISBNs in tabular format
            foreach (var element in authorsAndISBNs)
                buf.Append($"\r\n\t{element.FirstName,-10} " +
                           $"{element.LastName,-10} {element.ISBN,-10}");

            Console.WriteLine(buf.ToString());
        }
    }

    public static class Extentions
    {
        public static string ToTitleCase(this string s)
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s.ToLower());
        }
    }
}