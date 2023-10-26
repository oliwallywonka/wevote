using Microsoft.EntityFrameworkCore;
using WeVote.Entities;

namespace WeVote.Providers
{
    public class EFContext: DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        public DbSet<VisitEntity> Visit { get; set; }
        public DbSet<CountryEntity> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
