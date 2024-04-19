using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.StudentService;
using BusinessLogicLayer.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
    
        
        public StudentController(IStudentServices studentServices )
        {
            _studentServices = studentServices;
        }

        [HttpGet("GetStudent")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudent()
        {

            var students = await _studentServices.GetAllStudentAsync();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);

        }

        [HttpGet("GetStudentByID")]
        public async Task<ActionResult<StudentDTO>> GetStudentByID(string id)
        {
            var students = await _studentServices.GetStudentByIDAsync(id);

            if (students == null)
            {
                return StatusCode(404, " No Student found");
            }

            return Ok(students);
        }     

    }
}
