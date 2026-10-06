using System.Security.Claims;
using StudyDashboardBackend.Data;
using StudyDashboardBackend.Dtos;
using StudyDashboardBackend.Models;

namespace StudyDashboardBackend.Services
{
    public class CourseService(StudyDashboardDbContext context, IConfiguration configuration) : ICourseService
    {
        public async Task<Course> createCourse(CreateCourseDto courseRequest, Guid userId)
        {
            var newCourse = new Course{
                Code = courseRequest.Code,
                Name = courseRequest.Name,
                Description = courseRequest.Description,
                Credits = courseRequest.Credits,
                Semester = courseRequest.Semester,
                IsActive=true,
                UserId = userId
            };
            return newCourse;
        }
    }
}