using StudyDashboardBackend.Models;
using StudyDashboardBackend.Dtos;

namespace StudyDashboardBackend.Services
{
    public interface ICourseService
    {
        Task<Course> CreateCourseAsync(CreateCourseDto courseRequest, Guid userId);
        Task<List<ListCourseDto>>ListUsersCoursesAsync(Guid userId, CourseQueryParms courseQueryParms);
        Task<DetailCourseDto?> DetailCourseAsync(Guid userId, Guid courseId);
        Task<List<ListCourseDto>> ListUsersActiveCoursesAsync(Guid userId);
        Task DeleteCourseAsync(Guid userId, Guid courseId);
        Task UpdateCourseAsync(UpdateCourseDto courseRequest, Guid userId, Guid courseId);
    }
}