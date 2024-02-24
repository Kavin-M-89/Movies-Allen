using Movies.Entity;
using Movies.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Repository.QueryRepository
{
    public class ReviewQueryRepository : IReviewQueryRepository
    {
        /// <summary>
        /// Returns the reviews given to a movie
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public List<ReviewEntity> GetReviewsByMovieIDList(int movieID)
        {
            return DBEntity.ReviewList.Where(i => i.MovieID == movieID).ToList();
        }
    }
}
