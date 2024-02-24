using Movies.DTO;
using Movies.InterfaceBL;
using Movies.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.BL
{
    public class ActorBL: IActorBL
    {
        private IPersonQueryRepository personRepo;
        private IRoleQueryRepository roleRepo;
        private IMoviePersonMappingQueryRepository mappingRepo;
        private IMovieQueryRepository movieRepo;
        public ActorBL(IPersonQueryRepository _personRepo, IRoleQueryRepository _roleRepo,
            IMoviePersonMappingQueryRepository _mappingRepo, IMovieQueryRepository _movieRepo)
        {
            personRepo = _personRepo;
            roleRepo = _roleRepo;
            mappingRepo = _mappingRepo;
            movieRepo = _movieRepo;
        }

        /// <summary>
        /// Get details of a movie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActorMovieResponseDTO GetMovieDetails(string name)
        {
            try
            {
                ActorMovieResponseDTO response = new ActorMovieResponseDTO();
                int? personID = personRepo.GetPersonIDByName(name);
                if (personID == 0 || personID == null)
                {
                    response.Message = "Actor does not exist - " + name;
                    response.Message_Type = MovieResponseDTO.MESSAGE_TYPE_ERROR;
                    return response;
                }
                var roleID = roleRepo.GetRoleIDByName(Constants.Actor);
                List<int> movieIDs = mappingRepo.GetByPersonIDAndRoleID(Convert.ToInt32(personID), roleID);
                if (movieIDs != null && movieIDs.Count > 0)
                    response.Movies = movieRepo.GetNameByIDList(movieIDs);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
