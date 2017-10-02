using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WeddingPhotos.Data.Entities;

namespace WeddingPhotos.Data
{
    public class WeddingDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        private string _connectionString;

        public WeddingDbContext(string path = null)
        {
            _connectionString = string.IsNullOrEmpty(path) ?
                "Data Source=wedding.db" :
                $"Data Source={path}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}
