using Movies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.InterfaceRepo
{
    public interface IMoviePersonMappingQueryRepository
    {
        public List<MoviePersonMappingEntity> GetMoviePersonMappingList();
        public List<int> GetByMovieIDAndRoleID(int movieID, int roleID);
        public List<int> GetByPersonIDAndRoleID(int personID, int roleID);
    }
}
