using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroService1.Data.Context;
using MicroService1.Data.Entities;
using MicroService1.Models;
using MicroService1.Services.Abstractions;

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
        public async Task<ActionResult<StudentCoursexRef>> GetStudentCoursexRef(int id)
        {
            if (_context.StudentCoursexRef == null)
            {
                return NotFound();
            }
            var studentCoursexRef = await _context.StudentCoursexRef.FindAsync(id);

            if (studentCoursexRef == null)
            {
                return NotFound();
            }

            return studentCoursexRef;
        }

        // PUT: api/StudentCoursexRefs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutStudentCoursexRef(StudentCoursexRef studentCoursexRef)
        {
            var serviceResponse = await _userCourseService.UpdateItem(studentCoursexRef);

            return serviceResponse.ToApiResult();

        }

        // POST: api/StudentCoursexRefs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentCoursexRef>> PostStudentCoursexRef(StudentCoursexRef studentCoursexRef)
        {
            if (_context.StudentCoursexRef == null)
            {
                return Problem("Entity set 'LectureContext.StudentCoursexRef'  is null.");
            }
            _context.StudentCoursexRef.Add(studentCoursexRef);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentCoursexRef", new { id = studentCoursexRef.Id }, studentCoursexRef);
        }

        // DELETE: api/StudentCoursexRefs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentCoursexRef(int id)
        {
            if (_context.StudentCoursexRef == null)
            {
                return NotFound();
            }
            var studentCoursexRef = await _context.StudentCoursexRef.FindAsync(id);
            if (studentCoursexRef == null)
            {
                return NotFound();
            }

            _context.StudentCoursexRef.Remove(studentCoursexRef);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentCoursexRefExists(int id)
        {
            return (_context.StudentCoursexRef?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
