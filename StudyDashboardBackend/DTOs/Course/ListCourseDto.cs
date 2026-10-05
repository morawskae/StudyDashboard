namespace StudyDashboardBackend.Dtos
{
    public class ListCourseDto
    {
        public required int Id {get;set;}
        public required string Code {get;set;}
        public required string Name {get;set;}
        public required int Credits {get;set;}
    }
}