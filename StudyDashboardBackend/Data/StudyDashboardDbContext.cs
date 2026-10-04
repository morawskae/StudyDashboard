using Microsoft.EntityFrameworkCore;

namespace StudyDashboardBackend.Data;
    public class StudyDashboardDbContext : DbContext
{
    public StudyDashboardDbContext(DbContextOptions<StudyDashboardDbContext> options): base(options)
    {
        
    }
}
