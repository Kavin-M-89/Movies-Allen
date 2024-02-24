using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.DTO
{
    public class ActorMovieResponseDTO : MessageDTO
    {
        public List<string> Movies { get; set; }
    }
}
