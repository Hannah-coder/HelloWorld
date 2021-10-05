using System;

namespace API.Models
{
    public record PageView
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string URLSection1 { get; set; }
        public string URLSection2 { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
    }
}