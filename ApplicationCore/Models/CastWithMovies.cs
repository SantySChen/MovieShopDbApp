using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CastWithMovies
    {
        public Cast Cast { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
