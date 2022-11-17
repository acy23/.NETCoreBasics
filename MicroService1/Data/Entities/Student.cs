using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MicroService1.Data.Entities;
using Newtonsoft.Json;

namespace MicroService1.Data.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        public virtual ICollection<StudentCoursexRef>? StudentCourses { get; set; }
    }
}