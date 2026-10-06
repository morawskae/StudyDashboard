using StudyDashboardBackend.Models;
using StudyDashboardBackend.Dtos;

namespace StudyDashboardBackend.Services
{
    public interface ICourseService
    {
        Task<Course> CreateCourseAsync(CreateCourseDto courseRequest, Guid userId);
        Task<List<ListCourseDto>>ListUsersCoursesAsync(Guid userId);
        Task<DetailCourseDto?> DetailCourseAsync(Guid userId, int courseId);
        Task DeleteCourseAsync(Guid userId, int courseId);
        Task UpdateCourseAsync(UpdateCourseDto courseRequest, Guid userId, int courseId); //better practice to return the course or not?
    }
}