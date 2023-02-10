using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class  MovieFormContext : DbContext
    {
        // create constructor
        public MovieFormContext (DbContextOptions<MovieFormContext> options) : base (options)
        {

        }
        public DbSet<FormResponse> responses { get; set; }

        // seed the database with 3 movies
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<FormResponse>().HasData(
                new FormResponse
                {
                    FormId = 1,
                    Category = "Comedy",
                    Title = "The Proposal",
                    Year = 2009,
                    Director = "Anne Fletcher",
                    Rating = "PG-13",
                },

                new FormResponse
                {
                    FormId = 2,
                    Category = "Drama",
                    Title = "27 Dresses",
                    Year = 2008,
                    Director = "Anne Fletcher",
                    Rating = "PG-13",
                },

                new FormResponse
                {
                    FormId = 3,
                    Category = "Comedy",
                    Title = "The Other Woman",
                    Year = 2014,
                    Director = "Nick Cassavetes",
                    Rating = "PG-13",
                }
                );
        }
    }
}
