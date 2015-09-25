using System;
using System.Linq;
using System.Web;
using Assignment_2.Models;
using System.Collections.Generic;

namespace Assignment_2.Models
{
    public class MovieSessionsData
    {
        public IEnumerable<Cineplex> Cineplexes { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}