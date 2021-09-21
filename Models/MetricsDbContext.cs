using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class MetricsDbContext : DbContext
    {
        public MetricsDbContext(DbContextOptions<MetricsDbContext> options) : base(options)
        {

        }

        public DbSet<Session> Session { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<PageSession> PageSession { get; set; }
        public DbSet<Request> Request { get; set; }
    }
}
