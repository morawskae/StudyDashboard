using StudyDashboardBackend.Models;
using StudyDashboardBackend.Dtos;

namespace StudyDashboardBackend.Services
{
    public interface ICourseService
    {
        Task<Course> CreateCourseAsync(CreateCourseDto courseRequest, Guid userId);
        Task<List<ListCourseDto>>ListUsersCoursesAsync(Guid userId);
        Task<DetailCourseDto?> DetailCourseAsync(Guid userId, Guid courseId);
        Task DeleteCourseAsync(Guid userId, Guid courseId);
        Task UpdateCourseAsync(UpdateCourseDto courseRequest, Guid userId, Guid courseId); //better practice to return the course or not?
    }
}