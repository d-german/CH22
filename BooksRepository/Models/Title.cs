using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksRepository.Models
{
    public class Title
    {
        public Title()
        {
            Authors = new List<Author>();
        }
        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        public int EditionNumber { get; set; }
        public string Copyright { get; set; }

        public virtual List<Author> Authors { get; set; }
    }
}
