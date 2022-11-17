using Microservice1.Core.ServiceResults;
using MicroService1.Data.Entities;
using MicroService1.Models;
using Microservice1.Core;

namespace MicroService1.Services.Abstractions
{
    public interface IUserCourseService
    {
        Task<IServiceResult<List<StudentCoursesResponseModel>>> GetList();
        Task<IServiceResult<StudentCoursexRef>> UpdateItem(StudentCoursexRef studentCoursexRef);
    }
}
