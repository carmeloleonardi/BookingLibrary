using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookingLibrary.Models
{
    public class AuthorBiography
    {
        public int AuthorBiographyId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
        public string Nationality { get; set; }
        
        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
