using Movies.Entity;
using Movies.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Repository.QueryRepository
{
    public class MovieQueryRepository: IMovieQueryRepository
    {
        public List<MovieEntity> MovieList;

        /// <summary>
        /// Returns all the movies
        /// </summary>
        /// <returns></returns>
        public List<MovieEntity> GetMovieList()
        {
            this.MovieList = DBEntity.MovieList;
            return this.MovieList;
        }

        /// <summary>
        /// Returns the movie name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MovieEntity GetByName(string name)
        {
            if (this.MovieList == null)
                GetMovieList();
            return this.MovieList.Where(i=>i.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        /// <summary>
        /// Returns the movie names
        /// </summary>
        /// <param name="movieIDs"></param>
        /// <returns></returns>
        public List<string> GetNameByIDList(List<int> movieIDs)
        {
            if (this.MovieList == null)
                GetMovieList();
            return (from m in this.MovieList join id in movieIDs on m.ID equals id select m.Name).ToList();
        }

        /// <summary>
        /// Returns the list of movies of a particular genre
        /// </summary>
        /// <param name="genreID"></param>
        /// <returns></returns>
        public List<string> GetMoviesByGenre(string genreID)
        {
            if (this.MovieList == null)
                GetMovieList();
            return this.MovieList.Where(i => i.GenreIDs.Split(',').Contains(genreID)).Select(i => i.Name).ToList();
        }
    }
}
