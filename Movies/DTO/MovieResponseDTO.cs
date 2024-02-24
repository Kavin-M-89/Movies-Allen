using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.DTO
{
    public class MovieResponseDTO : MessageDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> Genre { get; set; }
        public List<string> Actors { get; set; }
        public List<string> Directors { get; set; }
        public List<Reviews> Reviews { get; set; }
    }

    public class Reviews
    {
        public string Reviewed_By { get; set; }
        public string Review { get; set; }
    }

}
