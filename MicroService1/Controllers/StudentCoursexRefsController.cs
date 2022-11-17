using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroService1.Data.Context;
using MicroService1.Data.Entities;
using MicroService1.Services.Abstractions;
using MicroService1.Models.ResponseModels;
using MicroService1.Models.RequestModels;

namespace MicroService1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursexRefsController : ControllerBase
    {
        private readonly LectureContext _context;
        private readonly IUserCourseService _userCourseService;

        public StudentCoursexRefsController(LectureContext context, IUserCourseService userCourseService)
        {
            _context = context;
            _userCourseService = userCourseService;
        }

        // GET: api/StudentCoursexRefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentCoursesResponseModel>>> GetStudentCoursexRef()
        {
            var serviceResult = await _userCourseService.GetList();

            return serviceResult.ToApiResult();
        }

        // GET: api/StudentCoursexRefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentCoursesResponseModel>> GetStudentCoursexRef(StudentCourseGetByIdRequest request)
        {
            var serviceResult = await _userCourseService.GetStudentCoursexRefById(request);

            return serviceResult.ToApiResult();
        
        }

        // PUT: api/StudentCoursexRefs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutStudentCoursexRef(StudentCourseUpdateRequest request)
        {
            var serviceResponse = await _userCourseService.UpdateItem(request);

            return serviceResponse.ToApiResult();

        }

        // POST: api/StudentCoursexRefs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentCoursexRef>> PostStudentCoursexRef(StudentCourseCreateRequest request)
        {
            var serviceResponse = await _userCourseService.CreateItem(request);

            return serviceResponse.ToApiResult();
        }

        // DELETE: api/StudentCoursexRefs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentCoursexRef(StudentCourseDeleteRequest request)
        {
            var serviceResponse = await _userCourseService.DeleteItem(request);

            return serviceResponse.ToApiResult();
        }

    }
}
