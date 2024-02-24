using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.DTO
{
    public class MessageDTO
    {
        public const short MESSAGE_TYPE_ERROR = 1;
        public const short MESSAGE_TYPE_WARNING = 2;

        public short Message_Type { get; set; }
        public string Message { get; set; }
    }
}
