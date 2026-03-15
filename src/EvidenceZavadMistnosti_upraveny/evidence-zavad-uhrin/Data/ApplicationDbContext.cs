using evidence_zavad_uhrin.Models;
using evidence_zavad_uhrin.Entities;
using Microsoft.EntityFrameworkCore;

namespace evidence_zavad_uhrin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<Issues> Issues { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4c1_uhrinpatrik_db1;uid=uhrinpatrik;password=123456");
        }
    }
}


