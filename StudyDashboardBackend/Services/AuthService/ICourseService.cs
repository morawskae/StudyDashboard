using StudyDashboardBackend.Models;
using StudyDashboardBackend.Dtos;

namespace StudyDashboardBackend.Services
{
    public interface ICourseService
    {
        Task<Course> createCourse(CreateCourseDto courseRequest, Guid userId);
    }
}