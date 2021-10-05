using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public record PetFilter
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public DateTimeOffset Time { get; set; }
        //public int Count { get; set; }
    }
}
