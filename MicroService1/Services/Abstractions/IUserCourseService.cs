using Microservice1.Core.ServiceResults;
using MicroService1.Data.Entities;
using Microservice1.Core;
using Microsoft.AspNetCore.Mvc;
using MicroService1.Models.ResponseModels;
using MicroService1.Models.RequestModels;

namespace MicroService1.Services.Abstractions
{
    public interface IUserCourseService
    {
        Task<IServiceResult<List<StudentCoursesResponseModel>>> GetList();
        Task<IServiceResult<StudentCoursesResponseModel>> UpdateItem(StudentCourseUpdateRequest request);
        Task<IServiceResult<StudentCoursesResponseModel>> GetStudentCoursexRefById(StudentCourseGetByIdRequest request);
        Task<IServiceResult<StudentCoursesResponseModel>> CreateItem(StudentCourseCreateRequest request);
        Task<IServiceResult> DeleteItem(StudentCourseDeleteRequest request);

    }
}
