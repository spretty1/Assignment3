using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models.ViewModels
{
    public class MovieListViewModel
    {
        //makes it so our program can enumerate through all of the Tour objects
        public IEnumerable<Movie> Movies { get; set; }
    }
}
