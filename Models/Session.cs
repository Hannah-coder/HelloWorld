using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public record Session
    {
        public int Id { get; init; }
        public DateTimeOffset Start_Time { get; init; }
        public DateTimeOffset End_Time { get; init; }
    }
}
