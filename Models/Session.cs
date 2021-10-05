using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public record Session
    {
        public int Id { get; set; }
        public DateTimeOffset Start_Time { get; set; }
        public DateTimeOffset End_Time { get; set; }
        [JsonIgnore]
        public ICollection<PageSession> PageSessions { get; set; }
    }
}
