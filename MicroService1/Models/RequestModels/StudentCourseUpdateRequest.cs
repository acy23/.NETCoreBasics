namespace MicroService1.Models.RequestModels
{
    public class StudentCourseUpdateRequest
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
