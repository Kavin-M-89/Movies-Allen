using Movies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.InterfaceBL
{
    public interface IMovieBL
    {
        public MovieResponseDTO GetMovieByName(string name);
    }
}
