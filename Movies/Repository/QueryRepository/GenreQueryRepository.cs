using Movies.Entity;
using Movies.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Repository.QueryRepository
{
    public class GenreQueryRepository : IGenreQueryRepository
    {
        public List<GenreEntity> GenreList = null;

        /// <summary>
        /// Returns all the Genres
        /// </summary>
        /// <returns></returns>
        public List<GenreEntity> GetGenreList()
        {
            this.GenreList = DBEntity.GenreList;
            return this.GenreList;
        }

        /// <summary>
        /// Returns the genre name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNameByID(int id)
        {
            if (this.GenreList == null)
                GetGenreList();
            return this.GenreList.Where(i => i.ID == id).Select(i => i.Name).FirstOrDefault();
        }

        /// <summary>
        /// Returns the genre ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int? GetIDByName(string name)
        {
            if (this.GenreList == null)
                GetGenreList();
            return this.GenreList.Where(i => i.Name.ToLower() == name.ToLower()).Select(i => i.ID).FirstOrDefault();
        }

    }
}
