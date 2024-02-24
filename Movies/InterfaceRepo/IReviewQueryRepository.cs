using Movies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.InterfaceRepo
{
    public interface IReviewQueryRepository
    {
        public List<ReviewEntity> GetReviewsByMovieIDList(int movieID);
    }
}
