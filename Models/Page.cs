using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public record Page
    {
        public int Id { get; init; }
        public string PageUrl { get; init; }
    }
}
