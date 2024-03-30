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

        public FacultyController(IFacultyServices facultyServices)
        {
            _facultyServices = facultyServices;
        }
        [HttpGet("GetFaculty")]
        public async Task<ActionResult<IEnumerable<FacultyDTO>>> get_faculties()
        {
            
            var faculties = await _facultyServices.GetAllFacultyAsync();
            if (faculties == null)
            {
                return StatusCode(404, "No Faculty Found");  
            }

            return Ok(faculties);

        }



        [HttpGet("GetFaculty/{id}")]
        public async Task<ActionResult<FacultyDTO>> get_faculty_id(string id)
        {
            var facultydto = await _facultyServices.GetFacultyByIdAsync(id);

            if (facultydto == null)
            {
                return StatusCode(404);
            }

            return Ok(facultydto);
        }

        [HttpGet("GetStudent/{Id}")]
        public async Task<ActionResult<FacultyDTO>> get_student_id(string id)
        {
            return StatusCode(404);
        }

        [HttpGet("GetStudent")]
        public async Task<ActionResult<FacultyDTO>> get_students(string id)
        {
            var user = await _facultyServices.GetFacultyByIdAsync(id);

            if (user == null)
            {
                return StatusCode(404);
            }

            return Ok(user);
        }
        

        
        [HttpGet("GetContribution")]
        public async Task<ActionResult<FacultyDTO>> get_contributors(string id)
        {
            var user = await _facultyServices.GetFacultyByIdAsync(id);

            if (user == null)
            {
                return StatusCode(404);
            }

            return Ok(user);
        }
        
        [HttpGet("GetContribution/{id}")]
        public async Task<ActionResult<FacultyDTO>> get_contributor(string id)
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
