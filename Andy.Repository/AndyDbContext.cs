using Andy.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Andy.Persistent
{
    public class AndyDbContext(DbContextOptions<AndyDbContext> options) : DbContext(options)
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<EssentialExpense> EssentialExpenses { get; set; }
    }
}
