using Microsoft.EntityFrameworkCore;
using StudyDashboardBackend.Models;

namespace StudyDashboardBackend.Data
{
    public class StudyDashboardDbContext : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<Course> Courses {get;set;}
        public DbSet<Grade> Grades {get;set;}
        public StudyDashboardDbContext(DbContextOptions<StudyDashboardDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurateCourse(modelBuilder);
            ConfigurateGrades(modelBuilder);

        }
        private void ConfigurateCourse(ModelBuilder modelBuilder)
        {
            var course = modelBuilder.Entity<Course>();

            course.HasKey(c=>c.Id);
            course.Property(c=>c.Name).IsRequired().HasMaxLength(100);
            course.Property(c=>c.Code).IsRequired().HasMaxLength(20);
            course.Property(c=>c.Description).HasMaxLength(250);
            course.Property(c=>c.Credits).IsRequired();
            course.Property(c=>c.Semester).IsRequired();
            course.Property(c=>c.IsActive).HasDefaultValue(true);
            course.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Course_Semester",
                    "[Semester]>=1 AND [Semester]<=7"
                );
                t.HasCheckConstraint(
                    "CK_Course_Credits",
                    "[Credits]>=1 AND [Credits]<=10");
            });
            course.HasOne(c=>c.User).WithMany(u=>u.Courses)
            .HasForeignKey(c=>c.UserId).IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        }
        private void ConfigurateGrades(ModelBuilder modelBuilder)
        {
            var grades = modelBuilder.Entity<Grade>();
            grades.HasKey(g=>g.Id);
            grades.Property(g=>g.Name).IsRequired().HasMaxLength(150);
            grades.Property(g=>g.Value).IsRequired();
            grades.Property(g=>g.Weight).IsRequired();

            grades.HasOne(g=>g.Course).WithMany(c=>c.Grades).HasForeignKey(c=>c.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

            grades.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Grade_Value",
                    "[Value] IN (2.0, 3.0, 3.5, 4.0, 4.5, 5.0)"
                );
                t.HasCheckConstraint(
                    "CK_Grade_Weight",
                    "[Weight]>=1 AND [Weight]<=10"
                );
            }
            );
        }
    }
}