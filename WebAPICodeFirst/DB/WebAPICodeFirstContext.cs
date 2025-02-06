using Microsoft.EntityFrameworkCore;
using WebAPICodeFirst.DB.Entity;

namespace WebAPICodeFirst.DB
{
    public class WebAPICodeFirstContext : DbContext
    {
        public WebAPICodeFirstContext(DbContextOptions<WebAPICodeFirstContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerInstrument> PlayerInstruments { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().HasMany(p => p.Instruments).WithOne(pi => pi.Player).HasForeignKey(pi => pi.PlayerId);
            modelBuilder.Seed();
        }
    }
}
