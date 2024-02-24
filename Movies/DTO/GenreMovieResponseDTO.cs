using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.DTO
{
    public class GenreMovieResponseDTO : MessageDTO
    {
        public List<string> Movies { get; set; }
    }
}
