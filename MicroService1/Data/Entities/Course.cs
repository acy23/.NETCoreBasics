using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MicroService1.Data.Entities;
using Newtonsoft.Json;

namespace MicroService1.Data.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public int PeriodId { get; set; }
        [ForeignKey(nameof(PeriodId))]
        public virtual Period? PeriodItem { get; set; }
        public virtual ICollection<StudentCoursexRef>? CourseStudents { get; set; }

    }
}
