using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WeddingPhotos.Data.Entities;

namespace WeddingPhotos.Data
{
    public class WeddingDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=wedding.db");
        }
    }
}
