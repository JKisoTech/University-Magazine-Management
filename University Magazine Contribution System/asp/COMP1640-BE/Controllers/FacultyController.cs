using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.FacultyService;
using BusinessLogicLayer.Services.User;
using BusinessLogicLayer.Services.UsersService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COMP1640_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyServices _facultyServices;


        [HttpGet("GetFaculty")]
        public async Task<ActionResult<IEnumerable<FacultyDTO>>> get_faculties()
        {

            var faculties = await _facultyServices.GetAllFacultyAsync();
            return Ok(faculties);

        }

        [HttpGet("GetFaculty/{Id}")]
        public async Task<ActionResult<FacultyDTO>> GetFacultyByID(int id)
        {
            var user = await _facultyServices.GetFacultyByIdAsync(id);

            if (user == null)
            {
                return StatusCode(404);
            }

            return Ok(user);
        }

        [HttpGet("GetStudent")]
        public async Task<ActionResult<FacultyDTO>> get_students(int id)
        {
            var user = await _facultyServices.GetFacultyByIdAsync(id);

            if (user == null)
            {
                return StatusCode(404);
            }

            return Ok(user);
        }
        
        
        [HttpGet("GetStudent/{id}")]
        public async Task<ActionResult<FacultyDTO>> get_student(int id)
        {
            var user = await _facultyServices.GetFacultyByIdAsync(id);

            if (user == null)
            {
                return StatusCode(404);
            }

            return Ok(user);
        }
        
        [HttpGet("GetContribution")]
        public async Task<ActionResult<FacultyDTO>> get_contributors(int id)
        {
            var user = await _facultyServices.GetFacultyByIdAsync(id);

            if (user == null)
            {
                return StatusCode(404);
            }

            return Ok(user);
        }
        
        [HttpGet("GetContribution/{id}")]
        public async Task<ActionResult<FacultyDTO>> get_contributor(int id)
        {
            var user = await _facultyServices.GetFacultyByIdAsync(id);

            if (user == null)
            {
                return StatusCode(404);
            }

            return Ok(user);
        }


    }
}
