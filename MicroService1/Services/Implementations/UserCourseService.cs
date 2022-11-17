using Microservice1.Core.ServiceResults;
using MicroService1.Data.Context;
using MicroService1.Data.Entities;
using MicroService1.Models;
using MicroService1.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MicroService1.Services.Implementations
{
    public class UserCourseService : IUserCourseService
    {
        private readonly LectureContext _context;
        public UserCourseService(LectureContext context)
        {
            _context = context;
        }
        public async Task<IServiceResult<List<StudentCoursesResponseModel>>> GetList()
        {
            var ls = await _context.StudentCoursexRef.Select(x => new StudentCoursesResponseModel()
            {
                CourseId = x.CourseId,
                CourseName = x.CourseItem.Name,
                Id = x.Id,
                PeriodId = x.CourseItem.PeriodId,
                PeriodName = x.CourseItem.PeriodItem.Name,
                StudentId = x.StudentId,
                StudentName = x.StudentItem.Name

            }).ToListAsync();

            return new OkResult<List<StudentCoursesResponseModel>>(ls);
        }

        public async Task<IServiceResult<StudentCoursexRef>> UpdateItem(StudentCoursexRef studentCoursexRef)
        {
            var item = await _context.StudentCoursexRef.Where(x=>x.Id == studentCoursexRef.Id).FirstOrDefaultAsync();  

            if(item == null)
            {
                return new NotFoundResult<StudentCoursexRef>("Not Found");
            }

            var student = await _context.Students.Where(x => x.Id == studentCoursexRef.StudentId).FirstOrDefaultAsync();

            if(student == default)
            {
                return new BusinessErrorResult<StudentCoursexRef>("Student id not valid.");
            }

            var course = await _context.Courses.Where(x => x.Id == studentCoursexRef.CourseId).FirstOrDefaultAsync();

            if (course == default)
            {
                return new BusinessErrorResult<StudentCoursexRef>("Course Id is not valid.");
            }

            item.StudentId = studentCoursexRef.StudentId;
            item.CourseId = studentCoursexRef.CourseId;

            await _context.SaveChangesAsync();

            return new OkResult<StudentCoursexRef>(item);
        }
    }
}
