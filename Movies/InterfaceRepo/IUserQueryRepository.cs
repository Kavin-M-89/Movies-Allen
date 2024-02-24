using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.InterfaceRepo
{
    public interface IUserQueryRepository
    {
        public string GetNameByID(int id);
    }
}
