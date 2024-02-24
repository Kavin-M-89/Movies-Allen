using Movies.Entity;
using Movies.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Repository.QueryRepository
{
    public class UserQueryRepository: IUserQueryRepository
    {
        public List<UserEntity> UserList = null;

        /// <summary>
        /// Returns all the users
        /// </summary>
        /// <returns></returns>
        public List<UserEntity> GetUserList()
        {
            if (this.UserList == null)
                this.UserList = DBEntity.UserList;
            return this.UserList;
        }

        /// <summary>
        /// Returns the user name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNameByID(int id)
        {
            if (this.UserList == null)
                GetUserList();
            return this.UserList.Where(i => i.ID == id).Select(i=>i.Name).FirstOrDefault();
        }
    }
}
