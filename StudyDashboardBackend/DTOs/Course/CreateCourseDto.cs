namespace StudyDashboardBackend.Dtos
{
    public class CreateCourseDto
    {
        public required int Id {get;set;}
        public required string Code {get;set;}
        public required string Name {get;set;}
        public required string Description {get;set;}
        public required int Credits {get;set;}
        public required int Semester {get;set;}
        public required bool IsActive {get;set;}
    }
}