using Andy.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Andy.Persistent
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
    }
}
