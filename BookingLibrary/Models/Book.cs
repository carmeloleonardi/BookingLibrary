using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace BookingLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public double Price { get; set; }
        public string Isbn { get; set; }

        public List<AuthorBook> AuthorBooks { get; set; } //= new List<AuthorBook>();

        public int EditorId { get; set; }
        public Editor Editor { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
