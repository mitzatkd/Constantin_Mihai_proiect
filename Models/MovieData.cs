﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Constantin_Mihai_proiect.Models
{
    public class MovieData
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<MovieGenre> MovieGenres { get; set; }
    }
}
