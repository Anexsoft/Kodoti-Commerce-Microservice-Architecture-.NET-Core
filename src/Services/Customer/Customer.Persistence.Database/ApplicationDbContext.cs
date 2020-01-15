using Customer.Domain;
using Microsoft.EntityFrameworkCore;
using Order.Persistence.Database.Configuration;

namespace Customer.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        )
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Database schema
            builder.HasDefaultSchema("Customer");

            // Model Contraints
            ModelConfig(builder);
        }

        public DbSet<Client> Clients { get; set; }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ClientConfiguration(modelBuilder.Entity<Client>());
        }
    }
}
