using Microsoft.EntityFrameworkCore;

namespace arq_micro_pru_tiempo.Models
{
    public class UserContext : DbContext
    {
        /**
         * Constructor del contexto de DB
         */
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<JobOffer> Offers { get; set; }
        public DbSet<OfferXUser> OfferXUsers { get; set; }
        public DbSet<TipDocument> TipDocument { get; set; }
        public DbSet<TipUser> TipUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(c => c.Id).IsUnique();
        }
    }
}
