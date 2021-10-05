using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public record PageSession
    {
        public int Id { get; init; }
        public DateTimeOffset Start_Time { get; init; }
        public DateTimeOffset End_Time { get; init; }
        public Decimal PageLoadTime { get; init; }
        public Session Session { get; set; }
        public int SessionId { get; init; }
        public Page Page { get; set; }
        public int PageId { get; init; }
    }
}
