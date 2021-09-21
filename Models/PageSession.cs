using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public record PageSession
    {
        public int Id { get; init; }
        public int SessionId { get; init; }
        public int PageId { get; init; }
        public DateTimeOffset Start_Time { get; init; }
        public DateTimeOffset End_Time { get; init; }
        public Decimal PageLoadTime { get; init; }
    }
}
