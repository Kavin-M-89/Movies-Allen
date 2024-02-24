using Movies.DTO;
using Movies.InterfaceBL;
using Movies.InterfaceRepo;
using Movies.Repository.QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.BL
{
    public class MovieBL : IMovieBL
    {
        private IPersonQueryRepository personRepo;
        private IRoleQueryRepository roleRepo;
        private IMoviePersonMappingQueryRepository mappingRepo;
        private IReviewQueryRepository reviewRepo;
        private IUserQueryRepository userRepo;
        private IGenreQueryRepository genreRepo;
        private IMovieQueryRepository movieRepo;
        public MovieBL(IGenreQueryRepository _genreRepo, IPersonQueryRepository _personRepo, IRoleQueryRepository _roleRepo, 
            IMoviePersonMappingQueryRepository _mappingRepo, IReviewQueryRepository _reviewRepo, IUserQueryRepository _userRepo,
            IMovieQueryRepository _movieRepo)
        {
            personRepo = _personRepo;
            roleRepo = _roleRepo;
            mappingRepo = _mappingRepo;
            reviewRepo = _reviewRepo;
            userRepo = _userRepo;
            genreRepo = _genreRepo;
            movieRepo = _movieRepo;
        }

        /// <summary>
        /// Get the detail of a movie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MovieResponseDTO GetMovieByName(string name)
        {
            try
            {
                MovieResponseDTO response = new MovieResponseDTO();
                var movie = movieRepo.GetByName(name);
                if (movie == null)
                {
                    response.Message = "Movie does not exist - " + name;
                    response.Message_Type = MovieResponseDTO.MESSAGE_TYPE_ERROR;
                    return response;
                }
                response.ID = movie.ID;
                response.Name = movie.Name;
                response.Genre = getGenres(movie.GenreIDs);
                response.Directors = getDirectors(movie.ID);
                response.Actors = getActors(movie.ID);
                response.Reviews = GetReviews(movie.ID);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all the reviews of a movie
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        private List<Reviews> GetReviews(int movieID)
        {
            var allReviews = reviewRepo.GetReviewsByMovieIDList(movieID);
            if (allReviews == null || allReviews.Count <= 0)
                return null;
            var reviews = (from review in allReviews
                          select new Reviews()
                          {
                              Reviewed_By = userRepo.GetNameByID(review.UserID),
                              Review = review.Review
                          }).ToList();
            return reviews;
        }

        /// <summary>
        /// Get all the actors acted in a movie
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        private List<string> getActors(int movieID)
        {
            var roleID = roleRepo.GetRoleIDByName(Constants.Actor);
            var actors = mappingRepo.GetByMovieIDAndRoleID(movieID, roleID);
            return personRepo.GetNameByIDList(actors);
        }

        /// <summary>
        /// Get all the directors, directed a movie
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        private List<string> getDirectors(int movieID)
        {
            var roleID = roleRepo.GetRoleIDByName(Constants.Director);
            var directors = mappingRepo.GetByMovieIDAndRoleID(movieID, roleID);
            return personRepo.GetNameByIDList(directors);
        }

        /// <summary>
        /// Get the genre names respective to their IDs
        /// </summary>
        /// <param name="genreIDs"></param>
        /// <returns></returns>
        private List<string> getGenres(string genreIDs)
        {
            List<string> genreResponse = new List<string>();
            if (!string.IsNullOrEmpty(genreIDs))
            {
                string[] movieGenres = genreIDs.Split(',');
                foreach(string genre in movieGenres)
                {
                    string value = genreRepo.GetNameByID(Convert.ToInt32(genre));
                    if (value != null)
                        genreResponse.Add(value);
                }
            }
            return genreResponse;
        }
    }
}
