namespace MicroService1.Models
{
    public class StudentCoursesResponseModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? PeriodId { get; set; }
        public string? PeriodName { get; set; }
    }
}
