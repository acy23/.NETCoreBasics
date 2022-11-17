using MicroService1.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroService1.Data.Entities
{
    public class StudentCoursexRef
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual Student? StudentItem { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course? CourseItem { get; set; }

    }
}
