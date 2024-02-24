using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Entity
{
    public class DBEntity
    {
        public static List<MovieEntity> MovieList = new List<MovieEntity>(){
            new MovieEntity() { ID = 1, Name="ABC", GenreIDs="2,3", Description="This movie was shoot is done in"},
            new MovieEntity() { ID = 2, Name="VKT", GenreIDs="2,4"},
            new MovieEntity() { ID = 3, Name="Past", GenreIDs="1"}
        };

        public static List<PersonEntity> PersonList = new List<PersonEntity>()
        {
            new PersonEntity(){ID = 1, Name ="Advik", Details="He started his movie career as cameraman"},
            new PersonEntity(){ID = 2, Name ="Raavan" },
            new PersonEntity(){ID = 3, Name ="Red" }
        };

        public static List<MoviePersonMappingEntity> MoviePersonMappingList = new List<MoviePersonMappingEntity>()
        {
            new MoviePersonMappingEntity(){ID = 1, RoleID =1, MovieID = 1, PersonID = 1},
            new MoviePersonMappingEntity(){ID = 2, RoleID =2, MovieID = 1, PersonID = 2},
            new MoviePersonMappingEntity(){ID = 3, RoleID =3, MovieID = 1, PersonID = 3},
            new MoviePersonMappingEntity(){ID = 4, RoleID =2, MovieID = 2, PersonID = 2},
            new MoviePersonMappingEntity(){ID = 5, RoleID =1, MovieID = 3, PersonID = 1},
            new MoviePersonMappingEntity(){ID = 6, RoleID =1, MovieID = 1, PersonID = 3},
            new MoviePersonMappingEntity(){ID = 4, RoleID =1, MovieID = 3, PersonID = 2},
        };

        public static List<GenreEntity> GenreList = new List<GenreEntity>()
        {
            new GenreEntity(){ID = 1, Name = "Thriller"},
            new GenreEntity(){ID = 2, Name = "Horror"},
            new GenreEntity(){ID = 3, Name = "Romance"},
            new GenreEntity(){ID = 4, Name = "Family"},
            new GenreEntity(){ID = 5, Name = "Suspense"},
        };

        public static List<RoleEntity> RoleList = new List<RoleEntity>()
        {
            new RoleEntity(){ID = 1, Name = "Actor"},
            new RoleEntity(){ID = 2, Name = "Director"},
            new RoleEntity(){ID = 3, Name = "Producer"}
        };

        public static List<ReviewEntity> ReviewList = new List<ReviewEntity>()
        {
            new ReviewEntity(){ID = 1, MovieID = 1, UserID = 2, Review = "Good"},
            new ReviewEntity(){ID = 2,  MovieID = 2, UserID = 2, Review = "Not Bad"},
            new ReviewEntity(){ID = 2,  MovieID = 1, UserID = 1, Review = "Not as expected"}
        };

        public static List<UserEntity> UserList = new List<UserEntity>()
        {
            new UserEntity(){ID = 1, Name = "Kavin"},
            new UserEntity(){ID = 2, Name = "Mohan"}
        };

        public static DateTime RecentDailyReportDate = new DateTime();

    }
}
