using Microsoft.EntityFrameworkCore;
using wSoftware1.Models;

namespace wSoftware1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //ignore

            ///llaves copuestas
        }

        // ------------------------------- DbSet
        public DbSet<Bitacora> Bitacora { get; set; }

    }
}
