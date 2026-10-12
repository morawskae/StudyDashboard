using System.ComponentModel.DataAnnotations;

namespace StudyDashboardBackend.Dtos
{
    public class ListGradeDto
    {

        public Guid Id {get;set;}
        public required string Name {get;set;}
        public decimal Value {get;set;}
        public int Weight {get;set;}
        public Guid CourseId {get;set;}

    }
}