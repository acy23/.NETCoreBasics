using Azure.Core;
using Microservice1.Core.ServiceResults;
using MicroService1.Data.Context;
using MicroService1.Data.Entities;
using MicroService1.Models.RequestModels;
using MicroService1.Models.ResponseModels;
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

        public async Task<IServiceResult<StudentCoursesResponseModel>> GetStudentCoursexRefById(StudentCourseGetByIdRequest request)
        {
            var item = await _context.StudentCoursexRef.Where(x => x.Id == request.Id).Select(x => new StudentCoursesResponseModel()
            {
                CourseId= x.CourseId,
                CourseName = x.CourseItem.Name,
                Id = x.Id,
                PeriodId= x.CourseItem.PeriodId,
                PeriodName = x.CourseItem.PeriodItem.Name,
                StudentId= x.StudentId,
                StudentName = x.StudentItem.Name
            }).SingleOrDefaultAsync();

            if(item == default)
            {
                return new NotFoundResult<StudentCoursesResponseModel>("Not Found");
            }

            return new OkResult<StudentCoursesResponseModel>(item);

        }

        public async Task<IServiceResult<StudentCoursesResponseModel>> UpdateItem(StudentCourseUpdateRequest request)
        {
            var item = await _context.StudentCoursexRef.Where(x=>x.Id == request.Id).FirstOrDefaultAsync();  
            if(item == null)
            {
                return new NotFoundResult<StudentCoursesResponseModel>("Not Found");
            }

            var student = await _context.Students.Where(x => x.Id == request.StudentId).FirstOrDefaultAsync();
            if(student == default)
            {
                return new BusinessErrorResult<StudentCoursesResponseModel>("Student id not valid.");
            }

            var course = await _context.Courses.Where(x => x.Id == request.CourseId).FirstOrDefaultAsync();
            if (course == default)
            {
                return new BusinessErrorResult<StudentCoursesResponseModel>("Course Id is not valid.");
            }

            item.StudentId = request.StudentId;
            item.CourseId = request.CourseId;

            await _context.SaveChangesAsync();

            return new OkResult<StudentCoursesResponseModel>(new StudentCoursesResponseModel()
            {
                Id = item.Id,
                CourseId = course.Id,
                StudentId = item.StudentId
            });
        }
        public async Task<IServiceResult<StudentCoursesResponseModel>> CreateItem(StudentCourseCreateRequest request)
        {

            var student = await _context.Students.Where(x => x.Id == request.StudentId).FirstOrDefaultAsync();
            if (student == default)
            {
                return new BusinessErrorResult<StudentCoursesResponseModel>("Student id not valid.");
            }

            var course = await _context.Courses.Where(x => x.Id == request.CourseId).FirstOrDefaultAsync();
            if (course == default)
            {
                return new BusinessErrorResult<StudentCoursesResponseModel>("Course Id is not valid.");
            }

            var item = new StudentCoursexRef();

            item.StudentId = request.StudentId;
            item.CourseId = request.CourseId;

            _context.StudentCoursexRef.Add(item);
            await _context.SaveChangesAsync();

            return new OkResult<StudentCoursesResponseModel>(new StudentCoursesResponseModel()
            {
                Id = item.Id,
                CourseId = course.Id,
                StudentId = item.StudentId
            });
        }

        public async Task<IServiceResult> DeleteItem(StudentCourseDeleteRequest request)
        {
            var item = await _context.StudentCoursexRef.Where(x => x.Id == request.Id).SingleOrDefaultAsync();
            if (item == default)
            {
                return new NotFoundResult("Not Found");
            }

            _context.Remove(item);
            await _context.SaveChangesAsync();

            return new NoContentResult();

        }
    }
}
