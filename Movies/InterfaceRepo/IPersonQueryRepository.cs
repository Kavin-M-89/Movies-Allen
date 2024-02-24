using Movies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.InterfaceRepo
{
    public interface IPersonQueryRepository
    {
        public List<PersonEntity> GetPersonList();
        public List<string> GetNameByIDList(List<int> personIDs);
        public int? GetPersonIDByName(string name);
    }
}
