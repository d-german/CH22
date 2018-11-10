using System.Collections.Generic;

namespace BooksRepository.Models
{
    public class Author //DTO
    {
        public Author()
        {
            Titles = new List<Title>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        public List<Title> Titles { get; set; }
    }
}