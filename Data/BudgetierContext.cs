using BudgetierApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetierApi.Data
{
    public class BudgetierContext : DbContext
    {
        public BudgetierContext(DbContextOptions<BudgetierContext> options)
        : base(options)
        { }

        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CategoryReportEntity> CategoryReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryReportEntity>()
                .HasKey(c => new { c.CategoryId, c.Year, c.Month });
        }
    }
}