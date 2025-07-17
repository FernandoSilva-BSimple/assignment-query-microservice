using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AssignmentContext : DbContext
    {
        public virtual DbSet<AssignmentDataModel> Assignments { get; set; }
        public virtual DbSet<DeviceDataModel> Devices { get; set; }
        public virtual DbSet<CollaboratorDataModel> Collaborators { get; set; }
        public virtual DbSet<UserDataModel> Users { get; set; }

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