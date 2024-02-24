using Movies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.InterfaceBL
{
    public interface IActorBL
    {
        public ActorMovieResponseDTO GetMovieDetails(string name);
    }
}
