using MicroService1.Data.Models;
using Microsoft.EntityFrameworkCore;
using MicroService1.Data.Entities;

namespace MicroService1.Data.Context
{
    public class LectureContext : DbContext
    {
        public LectureContext(DbContextOptions<LectureContext> options)
        : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<MicroService1.Data.Entities.StudentCoursexRef> StudentCoursexRef { get; set; } = default!;
    }
}
