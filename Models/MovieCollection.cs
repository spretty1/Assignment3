using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    public class MovieCollection
    {   
        //setting the different forms of data with some being required and the notes not being allowed to be longer than a certain length
        
        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters.")]
        public string Notes { get; set; }
    }
}
