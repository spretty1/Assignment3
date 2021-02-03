using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public static class TempStorage
    {
        private static List<MovieCollection> movies = new List<MovieCollection>();
        public static IEnumerable<MovieCollection> Movies => movies;
        public static void AddMovie(MovieCollection application)
        {
            movies.Add(application);
        }
    }
}
