using System.Security.Permissions;
using Microsoft.EntityFrameworkCore;
using StudyDashboardBackend.Data;
using StudyDashboardBackend.Dtos;
using StudyDashboardBackend.Models;

namespace StudyDashboardBackend.Services
{
    public class CourseService(StudyDashboardDbContext context, IConfiguration configuration) : ICourseService
    {
        public async Task<Course> CreateCourseAsync(CreateCourseDto courseRequest, Guid userId)
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
             context.Courses.Add(newCourse);
             await context.SaveChangesAsync();

            return newCourse;
        }

        public async Task DeleteCourseAsync(Guid userId, Guid courseId)
        {
            var course = await context.Courses.FirstOrDefaultAsync(c=>c.Id == courseId);
            if(course is null)
            {
                return;
            }
            if(userId != course.UserId)
            {
                throw new UnauthorizedAccessException();
            }
             context.Courses.Remove(course);
             await context.SaveChangesAsync();
        }

        public async Task<DetailCourseDto?> DetailCourseAsync(Guid userId,Guid courseId)
        {
            var course =  await context.Courses.FirstOrDefaultAsync(c=>c.Id == courseId);
            if(course is null)
            {
                return null;
            }
            if(userId != course.UserId)
            {
                throw new UnauthorizedAccessException();
            }
            return new DetailCourseDto
            {
                Id = course.Id,
                Code = course.Code,
                Name = course.Name,
                Description = course.Description,
                Credits = course.Credits,
                Semester = course.Semester,
                IsActive = course.IsActive

            };
        }

        public async Task<List<ListCourseDto>> ListUsersCoursesAsync(Guid userId)
        {
            return context.Courses
            .Where(c=>c.UserId == userId)
            .Select(c=> new ListCourseDto{
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                Credits = c.Credits
                }).ToList();

        }

        public async Task UpdateCourseAsync(UpdateCourseDto courseRequest, Guid userId, Guid courseId)
        {
            var course = await context.Courses.FirstOrDefaultAsync(c=>c.Id == courseId);
            if(course is null)
            {
                return;
            }
            if(course.UserId != userId)
            {
                throw new UnauthorizedAccessException();
            }
            course.Code = courseRequest.Code;
            course.Name = courseRequest.Name;
            course.Description = courseRequest.Description;
            course.Credits = courseRequest.Credits;
            course.Semester = courseRequest.Semester;
            course.IsActive = courseRequest.IsActive;

            await context.SaveChangesAsync();
        }
    }
}