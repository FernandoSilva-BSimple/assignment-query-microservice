using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AssignmentContext : DbContext
    {
        public virtual DbSet<AssignmentDataModel> Assignments { get; set; }

        public AssignmentContext(DbContextOptions<AssignmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignmentDataModel>().OwnsOne(a => a.PeriodDate);

            base.OnModelCreating(modelBuilder);
        }
    }
}