using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.DTO
{
    public class DailyReportDTO
    {
        public List<ActorMovieCountDTO> ActorMovieCountList { get; set; }
        public int GenreCount { get; set; }
        public List<MovieGenreCountDTO> MovieGenreCount { get; set; }
    }

    public class ActorMovieCountDTO
    {
        public string ActorName { get; set; }
        public int MovieCount { get; set; }
    }


    public class MovieGenreCountDTO
    {
        public string Genre { get; set; }
        public int MovieCount { get; set; }
    }
}
