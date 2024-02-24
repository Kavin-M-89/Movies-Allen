using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Entity
{
    public class MoviePersonMappingEntity
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int PersonID { get; set; }
        public int RoleID { get; set; }
    }
}
