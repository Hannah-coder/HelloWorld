using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public record ServerInformation
    {
        public int Id { get; set; }
        public TimeSpan Uptime { get; set; }
        public string RuntimeVersion { get; set; }
        public string OSVersion { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}
