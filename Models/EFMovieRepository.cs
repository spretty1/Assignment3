using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class EFMovieRepository: IMovieRepository
    {
        private MovieDbContext _context;

        //Constructor for setting the context 
        public EFMovieRepository(MovieDbContext context)
        {
            _context = context;
        }


        public IQueryable<Movie> Movies => _context.Movies;
    }
}
