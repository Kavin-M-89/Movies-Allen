using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Entity
{
    public class ReviewEntity
    {
        public int ID { get; set; }
        public string Review { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
    }
}
