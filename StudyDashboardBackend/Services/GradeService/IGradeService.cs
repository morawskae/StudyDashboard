using System;
using StudyDashboardBackend.Dtos;
using StudyDashboardBackend.Models;

namespace StudyDashboardBackend.Services;

public interface IGradeService
{
    Task<Grade> CreateGradeAsync(Guid userId, WriteGradeDto gradeRequest);
    Task<List<ListGradeDto>> ListGradesAsync(Guid userId);
    Task<DetailGradeDto> DetailGradeAsync(Guid userId);
    Task UpdateGradeAsync(Guid userId, Guid gradeId);
    Task DeleteGradeAsync(Guid userId, Guid gradeId);
}
