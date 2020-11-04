using BookingLibrary.Extensions;
using BookingLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingLibrary.Contexts
{
    public class BookingLibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<AuthorBiography> AuthorBiographies { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Category> Categories { get; set; }


        public BookingLibraryContext(DbContextOptions<BookingLibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Relationship();

            modelBuilder.Seed();
        }
    }
}
