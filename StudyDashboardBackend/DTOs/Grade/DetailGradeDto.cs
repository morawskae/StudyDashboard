using System.ComponentModel.DataAnnotations;

namespace StudyDashboardBackend.Dtos
{
    public class DetailGradeDto
    {
        public Guid Id {get;set;}
        public required string Name {get;set;}
        public decimal Value {get;set;}
        public int Weight {get;set;}
        public Guid CourseId {get;set;}
        public DateTime addedAt {get;set;}= DateTime.UtcNow;


    }
}