using System;

namespace API.Models
{
    public record ServerInformation
    {
        public int Id { get; set; }
        public TimeSpan UpTime { get; set; }
        public string RuntimeVersion { get; set; }
        public string OSVersion { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}