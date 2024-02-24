using Movies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.InterfaceRepo
{
    public interface IGenreQueryRepository
    {
        public List<GenreEntity> GetGenreList();
        public string GetNameByID(int id);
        public int? GetIDByName(string name);
    }
}
