using System;
using System.Text;
using BooksRepository;
using BooksRepository.Models;

namespace BooksRepoDriver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var booksRepo = new BooksRepository.BooksRepository();

            booksRepo.Add(
                new Author
                {
                    FirstName = "Damon",
                    LastName = "German"
                },
                new Title
                {
                    BookTitle = "Why it's Hard to Write Clean Code",
                    Copyright = "1998",
                    EditionNumber = 5,
                    ISBN = GetRandomString()
                },
                new Title
                {
                    BookTitle = "Why Map is my Favorite Data Structure",
                    Copyright = "2007",
                    EditionNumber = 1,
                    ISBN = GetRandomString()
                }
                );

            DisplayAuthorsAndTitles(booksRepo);
            DisplayAuthorsAndISBNs(booksRepo);
        }

        private static void DisplayAuthorsAndTitles(IBooksRepository booksRepo)
        {
            var buf = new StringBuilder();

            // display authors and titles in tabular format
            foreach (var element in booksRepo.GetAuthorsAndTitles())
                buf.Append($"\r\n\t{element.FirstName,-10} " +
                           $"{element.LastName,-10} {element.Title}");

            Console.WriteLine(buf.ToString());
        }

        private static void DisplayAuthorsAndISBNs(IBooksRepository booksRepo)
        {
            var buf = new StringBuilder();

            // display authors and ISBNs in tabular format
            foreach (var element in booksRepo.GetAuthorsAndISBNs())
                buf.Append($"\r\n\t{element.FirstName,-10} " +
                           $"{element.LastName,-10} {element.ISBN,-10}");

            Console.WriteLine(buf.ToString());
        }

        public static string GetRandomString(int length = 15)
        {
            var rnd = new Random();
            var charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvw xyz1234567890";
            var rs = new StringBuilder();

            while (length > 0)
            {
                rs.Append(charPool[(int)(rnd.NextDouble() * charPool.Length)]);
                length--;
            }

            return rs.ToString();
        }
    }
}