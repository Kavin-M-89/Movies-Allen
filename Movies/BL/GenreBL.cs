using Movies.DTO;
using Movies.InterfaceBL;
using Movies.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.BL
{
    public class GenreBL : IGenreBL
    {
        private IGenreQueryRepository genreRepo;
        private IMovieQueryRepository movieRepo;
        public GenreBL(IGenreQueryRepository _genreRepo, IMovieQueryRepository _movieRepo)
        {
            genreRepo = _genreRepo;
            movieRepo = _movieRepo;
        }

        /// <summary>
        /// Get all the movie names of a particular genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public GenreMovieResponseDTO GetMovies(string genre)
        {
            try
            {
                GenreMovieResponseDTO response = new GenreMovieResponseDTO();
                int? genreID = genreRepo.GetIDByName(genre);
                if (genreID == 0 || genreID == null)
                {
                    response.Message = "Genre does not exist - " + genre;
                    response.Message_Type = MovieResponseDTO.MESSAGE_TYPE_ERROR;
                    return response;
                }
                response.Movies = movieRepo.GetMoviesByGenre(genreID.ToString());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
