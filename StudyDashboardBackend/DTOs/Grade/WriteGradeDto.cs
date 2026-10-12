using System.ComponentModel.DataAnnotations;

namespace StudyDashboardBackend.Dtos
{
    public class WriteGradeDto
    {
        public required string Name {get;set;}
        public decimal Value {get;set;}
        public int Weight {get;set;}
        public Guid CourseId {get;set;}

    }
}