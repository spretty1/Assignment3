using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class MovieInfo
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MovieDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();
            //Checks to see if a migration already exists
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            //If one does not we input this data into the table
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(

                //data that will be used to seed the database
                new Movie
                {
                    Category = "Action/Adventure",
                    Title = "Avengers, The",
                    Year = "2012",
                    Director = "",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new Movie
                {
                    Category = "Action/Adventure",
                    Title = "Batman",
                    Year = "1989",
                    Director = "Tim Burton",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }





                );
                context.SaveChanges();

            }
        }
    }
}
