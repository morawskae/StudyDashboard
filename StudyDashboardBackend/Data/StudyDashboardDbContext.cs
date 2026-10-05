using Microsoft.EntityFrameworkCore;
using StudyDashboardBackend.Models;

namespace StudyDashboardBackend.Data
{
    public class StudyDashboardDbContext : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<Course> Courses {get;set;}
        public StudyDashboardDbContext(DbContextOptions<StudyDashboardDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}