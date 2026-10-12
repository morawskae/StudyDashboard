namespace StudyDashboardBackend.Models
{
    public class Grade
    {
        public Guid Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public decimal Value {get;set;}=2;
        public int Weight {get;set;}=1;
        public DateTime addedAt {get;set;}= DateTime.UtcNow;

        //fk
        public Guid CourseId {get;set;}
        public Course Course {get;set;}=null!;

    }
}