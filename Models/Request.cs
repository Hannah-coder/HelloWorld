using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public record Request
    {
        public int Id { get; set; }
        public DateTimeOffset Request_Time { get; set; }
        public bool Response { get; set; }
    }
}
