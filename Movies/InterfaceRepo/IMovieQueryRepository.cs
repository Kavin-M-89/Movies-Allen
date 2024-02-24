using Movies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.InterfaceRepo
{
    public interface IMovieQueryRepository
    {
        public MovieEntity GetByName(string name);
        public List<string> GetNameByIDList(List<int> movieIDs);
        public List<string> GetMoviesByGenre(string genreID);
        public List<MovieEntity> GetMovieList();
    }
}
