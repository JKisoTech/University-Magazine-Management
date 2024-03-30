using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.AuthenticateService;
using BusinessLogicLayer.Services.User;
using BusinessLogicLayer.Services.UsersService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }


        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDTO>> user_save([FromBody] UserDTO userDTO)
        {
            await _userServices.AddUserAsync(userDTO);
            return StatusCode(200, "User Added Successfully");
        }
        #region HttpGet
        [HttpGet("GetUser")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {

            var users = await _userServices.GetAllUserAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No Student Found");
            }
            return Ok(users);

        }
        [HttpGet("GetEmail")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersEmail()
        {

            return StatusCode(204, "Still doing");

        }
        
        [HttpGet("GetRole")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersRole()
        {

            return StatusCode(204, "Still doing");

        }
        
        [HttpGet("GetFaculties")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersFaculties()
        {

            return StatusCode(204, "Still doing");

        }


        
        [HttpGet("GetUserByLoginName")]
        public async Task<ActionResult<UserDTO>> GetUserByLoginName(string _loginName)
        {
            var user = await _userServices.GetUserByLoginNameAsync(_loginName);

            if (user == null)
            {
                return StatusCode(404, " No User found");
            }

            return Ok(user);
        }
        #endregion
       
        #region HttpPut
        [HttpPut("UpdateUser/{_loginName}")]

        public async Task<ActionResult> update_user(string _loginName, [FromBody] UserDTO userDTO)
        {
            if (_loginName != userDTO.LoginName)
            {
                return StatusCode(400, " No User Found");
            }

            await _userServices.UpdateUserAsync(userDTO);

            return NoContent();
        }

        [HttpPut("ChangePassword/{_loginName}")]
        public async Task<ActionResult<UserDTO>> change_user_pass(string _loginName, [FromBody] UserDTO userDto)
        {
            return StatusCode(204, "Still doing");
        }
        
        [HttpPut("BlockUser/{_loginName}")]
        public async Task<ActionResult<UserDTO>> user_block(string _loginName, [FromBody] UserDTO userDto)
        {
            return StatusCode(204, "Still doing");
        } 
        [HttpPut("UnBlockUser/{_loginName}")]
        public async Task<ActionResult<UserDTO>> user_unblock(string _loginName, [FromBody] UserDTO userDto)
        {
            return StatusCode(204, "Still doing");
        }
        #endregion


      

        //[HttpPost("signin")]
        //public IActionResult SignIn(string username, string password)
        //{
        //    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        //    {
        //        return BadRequest("Username and password cannot be empty.");
        //    }


        //    var userDto = _authenticationServices.Authenticate(username, password);
        //    if (userDto == null)
        //    {
        //        return Unauthorized("Invalid username or password.");
        //    }

        //    return Ok(userDto);
        //}
    }
}
