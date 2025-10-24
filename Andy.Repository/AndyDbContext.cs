using Andy.Core;
using Microsoft.EntityFrameworkCore;

namespace Andy.Repository
{
    public class AndyDbContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<EssentialExpense> EssentialExpenses { get; set; }

        public AndyDbContext(DbContextOptions<AndyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
