using System;

namespace API.Models
{
    public record ServerInformation
    {
        public int Id { get; init; }
        public TimeSpan UpTime { get; init; }
        public string RuntimeVersion { get; init; }
        public string OSVersion { get; init; }
        public DateTime DateAndTime { get; init; }
    }
}