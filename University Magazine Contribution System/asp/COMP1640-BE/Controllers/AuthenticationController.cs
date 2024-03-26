using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.AuthenticateService;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace COMP1640_BE.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationService;
        private readonly IAuthorizationServices _authorizationService;

        public AuthenticationController(IAuthenticationServices authenticationService, IAuthorizationServices authorizationService)
        {
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var _user = _authenticationService.Authenticate(user.LoginName, user.Password);
            if (user == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Authorize(Roles = "1")] 
        public IActionResult GetUserData(UserDTO userDTO)
        {
            var _user = _authorizationService.IsAuthorized(userDTO, "GetUserData");
            if (_user == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
