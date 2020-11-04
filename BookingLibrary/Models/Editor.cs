using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingLibrary.Models
{
    public class Editor
    {
        public int EditorId { get; set; }
        public string EditorName { get; set; }

        public List<Book> BooksPublished { get; set; }
    }
}
