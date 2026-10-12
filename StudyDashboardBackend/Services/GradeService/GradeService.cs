using StudyDashboardBackend.Dtos;
using StudyDashboardBackend.Models;
using StudyDashboardBackend.Data;


namespace StudyDashboardBackend.Services
{
    public class GradeService(StudyDashboardDbContext context): IGradeService
    {
        public async Task<Grade> CreateGradeAsync(Guid userId, WriteGradeDto gradeRequest)
        {
            if(!context.Courses.Any(c=>c.UserId==userId && c.Id == gradeRequest.CourseId))
            {
                throw new UnauthorizedAccessException();
            }
            var grade = new Grade
            {
                Name = gradeRequest.Name,
                Value = gradeRequest.Value,
                Weight = gradeRequest.Weight,
                CourseId = gradeRequest.CourseId,

            };
            await context.Grades.AddAsync(grade);
            await context.SaveChangesAsync();
            return grade;
        }

        public Task DeleteGradeAsync(Guid userId, Guid gradeId)
        {
            throw new NotImplementedException();
        }

        public Task<DetailGradeDto> DetailGradeAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ListGradeDto>> ListGradesAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGradeAsync(Guid userId, Guid gradeId)
        {
            throw new NotImplementedException();
        }
    }
}