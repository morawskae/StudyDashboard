namespace StudyDashboardBackend.Dtos
{
    public class CreateCourseDto
    {
        public required string Code {get;set;}
        public required string Name {get;set;}
        public string? Description {get;set;} = "";
        public required int Credits {get;set;}
        public required int Semester {get;set;}

    }
}