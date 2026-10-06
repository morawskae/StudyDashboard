namespace StudyDashboardBackend.Dtos
{
    public class ListCourseDto
    {
        public required Guid Id {get;set;}
        public required string Code {get;set;}
        public required string Name {get;set;}
        public required int Credits {get;set;}
    }
}