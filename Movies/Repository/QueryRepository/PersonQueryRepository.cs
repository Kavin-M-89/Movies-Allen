using Movies.Entity;
using Movies.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Repository.QueryRepository
{
    public class PersonQueryRepository : IPersonQueryRepository
    {
        public List<PersonEntity> PersonList = null;

        /// <summary>
        /// Returns all the persons
        /// </summary>
        /// <returns></returns>
        public List<PersonEntity> GetPersonList()
        {
            this.PersonList = DBEntity.PersonList;
            return this.PersonList;
        }

        /// <summary>
        /// Returns a person's ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int? GetPersonIDByName(string name)
        {
            if (this.PersonList == null)
                GetPersonList();
            return this.PersonList.Where(i => i.Name.ToLower() == name.ToLower()).Select(i => i.ID).FirstOrDefault();
        }

        /// <summary>
        /// Returns the list of persons names
        /// </summary>
        /// <param name="personIDs"></param>
        /// <returns></returns>
        public List<string> GetNameByIDList(List<int> personIDs)
        {
            if (this.PersonList == null)
                GetPersonList();
            return (from p in this.PersonList join id in personIDs on p.ID equals id select p.Name).ToList();
        }
    }
}
