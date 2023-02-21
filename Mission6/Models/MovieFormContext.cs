using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class MovieFormContext : DbContext
    {
        // create constructor
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
        {

        }
        public DbSet<FormResponse> responses { get; set; }
        public DbSet<Category> Categories {get; set; }

        // seed the database with 3 movies
        protected override void OnModelCreating(ModelBuilder mb)
        {

        mb.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
            new Category { CategoryId = 2, CategoryName = "Comedy" },
            new Category { CategoryId = 3, CategoryName = "Drama" },
            new Category { CategoryId = 4, CategoryName = "Family" },
            new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
            new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
            new Category { CategoryId = 7, CategoryName = "Television" },
            new Category { CategoryId = 8, CategoryName = "VHS" }

            );
            mb.Entity<FormResponse>().HasData(
                new FormResponse
                {
                    FormId = 1,
                    CategoryId = 2,
                    Title = "The Proposal",
                    Year = 2009,
                    Director = "Anne Fletcher",
                    Rating = "PG-13",
                },

                new FormResponse
                {
                    FormId = 2,
                    CategoryId = 3,
                    Title = "27 Dresses",
                    Year = 2008,
                    Director = "Anne Fletcher",
                    Rating = "PG-13",
                },

                new FormResponse
                {
                    FormId = 3,
                    CategoryId = 2,
                    Title = "The Other Woman",
                    Year = 2014,
                    Director = "Nick Cassavetes",
                    Rating = "PG-13",
                }
                ) ;
        }
    }
}
