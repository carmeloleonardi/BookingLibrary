using BookingLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingLibrary.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Relationship(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasKey(a => new { a.AuthorId, a.BookId });

            modelBuilder.Entity<AuthorBook>()
                .HasOne(a => a.Author)
                .WithMany(ab => ab.AuthorBooks)
                .HasForeignKey(k => k.AuthorId);

            modelBuilder.Entity<AuthorBook>()
                .HasOne(b => b.Book)
                .WithMany(ab => ab.AuthorBooks)
                .HasForeignKey(k => k.BookId);

            modelBuilder.Entity<Author>()
                .HasOne(b => b.Biography)
                .WithOne(a => a.Author)
                .HasForeignKey<AuthorBiography>(k => k.AuthorBiographyId);

            modelBuilder.Entity<Book>()
               .HasOne(e => e.Editor)
               .WithMany(b => b.BooksPublished)
               .HasForeignKey(k => k.EditorId);

            modelBuilder.Entity<Book>()
                .HasOne(c => c.Category)
                .WithMany(b => b.Books)
                .HasForeignKey(k => k.CategoryId);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasData(
                    new Author { AuthorId = 1, FirstName = "Italo", LastName = "Calvivo" },
                    new Author { AuthorId = 2, FirstName = "Italo", LastName = "Svevo" },
                    new Author { AuthorId = 3, FirstName = "Martin", LastName = "Fowler" },
                    new Author { AuthorId = 4, FirstName = "Erich", LastName = "Gamma" },
                    new Author { AuthorId = 5, FirstName = "Richard", LastName = "Helm" },
                    new Author { AuthorId = 6, FirstName = "Ralph", LastName = "Johnson" },
                    new Author { AuthorId = 7, FirstName = "John", LastName = "Vlissides" }
                );

            modelBuilder.Entity<Book>()
                .HasData(
                    new Book { BookId = 1, Isbn = "5ab6829o", Title = "Il sentiero dei nidi di ragno", Price = 13.5, EditorId=3, CategoryId=1 },
                    new Book { BookId = 2, Isbn = "7493b423", Title = "Il barone rampante", Price = 12.2, EditorId = 3, CategoryId = 1 },
                    new Book { BookId = 3, Isbn = "6283472992a", Title = "Il visconte dimezzato", Price = 13.5, EditorId = 3, CategoryId = 1 },
                    new Book { BookId = 4, Isbn = "3738347383", Title = "La coscienza di Zeno", Price = 17.5, EditorId = 3, CategoryId = 1 },
                    new Book { BookId = 5, Isbn = "127238437", Title = "UML distilled", Price = 24.5, EditorId = 4, CategoryId = 2},
                    new Book { BookId = 6, Isbn = "887192150X", Title = "Design Patterns", Price = 39.00, EditorId = 4, CategoryId = 2 }
                );

            modelBuilder.Entity<AuthorBook>()
                .HasData(
                    new AuthorBook { AuthorId = 1, BookId = 1 },
                    new AuthorBook { AuthorId = 1, BookId = 2 },
                    new AuthorBook { AuthorId = 1, BookId = 3 },
                    new AuthorBook { AuthorId = 2, BookId = 4 },
                    new AuthorBook { AuthorId = 3, BookId = 5 },
                    new AuthorBook { AuthorId = 4, BookId = 6 },
                    new AuthorBook { AuthorId = 5, BookId = 6 },
                    new AuthorBook { AuthorId = 6, BookId = 6 },
                    new AuthorBook { AuthorId = 7, BookId = 6 }
                );

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { CategoryId = 1, CategoryName = "Narrative" },
                    new Category { CategoryId = 2, CategoryName = "Computer Science" },
                    new Category { CategoryId = 3, CategoryName = "Thriller" },
                    new Category { CategoryId = 4, CategoryName = "Horror" },
                    new Category { CategoryId = 5, CategoryName = "Romantic" },
                    new Category { CategoryId = 6, CategoryName = "Crime" }
                );

            modelBuilder.Entity<Editor>()
                .HasData(
                    new Editor { EditorId = 1, EditorName = "Rizzoli" },
                    new Editor { EditorId = 2, EditorName = "PACKT" },
                    new Editor { EditorId = 3, EditorName = "Mondadori" },
                    new Editor { EditorId = 4, EditorName = "PEARSON Addison Wesley" },
                    new Editor { EditorId = 5, EditorName = "Mondadori" }
                );

            modelBuilder.Entity<AuthorBiography>()
                .HasData(
                    new AuthorBiography
                    {
                        AuthorBiographyId = 1,
                        AuthorId = 3,
                        DateOfBirth = new DateTime(1963, 12, 18),
                        Nationality = "England",
                        Description = "Together with Kent Beck he was one of the fathers of extreme programming and agile software development. " +
                        "He is a member of the Agile Alliance and one of the authors of the Agile Manifesto. " +
                        "Among his most influential works we can mention UML Distilled on the UML language and Refactoring: " +
                        "Improving the Design of Existing Code which introduced the concept of refactoring, " +
                        "today among the cornerstones of agile and test driven development methodologies. " +
                        "He introduced the concept of dependency injection, " +
                        "widely used in the practice of developing automated tests."
                    }
                );
        }
    }
}
