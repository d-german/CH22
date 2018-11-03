using System;
using System.Text;
using BooksRepository;

namespace BooksRepoDriver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var booksRepo = new BooksRepo();

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
    }
}