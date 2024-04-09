using Azure.Core;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.User;
using BusinessLogicLayer.Services.UsersService;
using DataAccessLayer.Models;
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

        #region HttpPost
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserDTO>> Login(string _loginName, string _password)
        {
        
            var user = await _userServices.UserLogin(_loginName, _password);

            if (user == null)
            {
                return NotFound("User Not Found.");
            } 

            return Ok(user);
        }

        [HttpPost]
        [Route("AdminLogin")]
        public async Task<ActionResult<UserDTO>> AdminLogin(string _loginName, string _password)
        {

            var admin = await _userServices.AdminLogin(_loginName, _password);

            if (admin == null)
            {
                return NotFound("User Not Found.");
            }

            return Ok(admin);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDTO>> user_save([FromBody] UserDTO userDTO, string facultyID)
        {
            
            if (userDTO.FacultyID == "2")
            {
                userDTO.FacultyID = null;
            }
            await _userServices.AddUserAsync(userDTO, facultyID);
            return StatusCode(200, "User Added Successfully");
        }

        #endregion

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
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersRole(string _loginName)
        {

            var user = await _userServices.GetUserByLoginNameAsync(_loginName);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

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


            //if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            //{
            //    return BadRequest("All fields are required.");
            //}
            //if (newPassword != confirmPassword)
            //{
            //    return BadRequest("The new password and confirmation password do not match.");
            //}
            //var userName = _userServices.GetUserByLoginNameAsync(loginName);
            //if (userName == null)
            //{
            //    return NotFound("User not found.");
            //}
            //var isOld = await _userServices.user_change_password(loginName, oldPassword);

            //if (!isOld)
            //{
            //    return BadRequest("Incorrect Old Password !");
            //}
            //var updatedUser = await _userServices.user_change_password(loginName, newPassword);
            //_userServices.UpdateUserAsync(updatedUser);
            return Ok();
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


      

       
    }
}
