using Movies.Entity;
using Movies.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Repository.QueryRepository
{
    public class RoleQueryRepository: IRoleQueryRepository
    {
        public List<RoleEntity> RoleList = null;

        /// <summary>
        /// Returns all the roles
        /// </summary>
        /// <returns></returns>
        public List<RoleEntity> GetRoleList()
        {
            this.RoleList = DBEntity.RoleList;
            return this.RoleList;
        }

        /// <summary>
        /// Returns the role id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetRoleIDByName(string name)
        {
            if (this.RoleList == null)
                GetRoleList();
            return this.RoleList.Where(i=>i.Name==name).Select(i=>i.ID).FirstOrDefault();
        }

    }
}
