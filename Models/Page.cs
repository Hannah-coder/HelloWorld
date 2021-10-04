using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public record Page
    {
        public int Id { get; init; }
        public string Page_Url { get; init; }
        public ICollection<PageSession> PageSessions { get; set; }
    }
}
