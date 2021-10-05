using System;

namespace API.Models
{
    public record PageView
    {
        public int Id { get; init; }
        public DateTime DateAndTime { get; init; }
        public string URLSection1 { get; init; }
        public string URLSection2 { get; init; }
        public string Parameter1 { get; init; }
        public string Parameter2 { get; init; }
    }
}