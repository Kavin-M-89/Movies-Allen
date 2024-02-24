using Movies.Entity;
using Movies.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Repository.QueryRepository
{
    public class MoviePersonMappingQueryRepository : IMoviePersonMappingQueryRepository
    {
        public List<MoviePersonMappingEntity> MoviePersonMappingList;

        /// <summary>
        /// Returns all the movie person role mapping
        /// </summary>
        /// <returns></returns>
        public List<MoviePersonMappingEntity> GetMoviePersonMappingList()
        {
            this.MoviePersonMappingList = DBEntity.MoviePersonMappingList;
            return this.MoviePersonMappingList;
        }

        /// <summary>
        /// Returns the movie person role mapping based on movie and role
        /// </summary>
        /// <param name="movieID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public List<int> GetByMovieIDAndRoleID(int movieID, int roleID)
        {
            if (MoviePersonMappingList == null)
                GetMoviePersonMappingList();
            return this.MoviePersonMappingList.Where(i => i.MovieID == movieID && i.RoleID == roleID).Select(i => i.PersonID).ToList();
        }

        /// <summary>
        /// Returns the movie person role mapping based on person and role
        /// </summary>
        /// <param name="personID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public List<int> GetByPersonIDAndRoleID(int personID, int roleID)
        {
            if (MoviePersonMappingList == null)
                GetMoviePersonMappingList();
            return this.MoviePersonMappingList.Where(i => i.PersonID == personID && i.RoleID == roleID).Select(i => i.MovieID).ToList();
        }

    }
}
