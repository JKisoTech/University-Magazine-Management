using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.AuthenticateService;
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
        private readonly IAuthenticationServices _authenticationServices;
        
        public StudentController(IStudentServices studentServices, IAuthenticationServices authenticationServices)
        {
            _studentServices = studentServices;
            _authenticationServices = authenticationServices;
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

        [HttpGet("GetStudentBy/{LoginName}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(string id)
        {
            var students = await _studentServices.GetStudentByIdAsync(id);

            if (students == null)
            {
                return StatusCode(404, " No Student found");
            }

            return Ok(students);
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<StudentDTO>> CreateUser([FromBody] StudentDTO studentDTO)
        {
            await _studentServices.AddStudentAsync(studentDTO);

            return StatusCode(200, "Student Added Successfully");
        }

       

       

    }
}
