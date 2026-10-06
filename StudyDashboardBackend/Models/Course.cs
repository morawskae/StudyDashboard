namespace StudyDashboardBackend.Models
{
    
    public class Course
    {
        public Guid Id {get;set;}
        public string Code {get;set;} = string.Empty;
        public string Name {get;set;}= string.Empty;
        public string Description {get;set;}=string.Empty;
        public int Credits {get;set;}=1; //limit the credit int to positive numbers
        public int Semester {get;set;}=1; //limit the semester int to range 1-7
        public bool IsActive {get;set;}=true;

        //relationship config
        public Guid UserId {get;set;}
        public User User {get;set;}=null!;

    }
}