using BusinessLogicLayer.DTOs;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AuthenticateService
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationServices(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public UserDTO Authenticate(string _loginName, string password)
        {
            var user = _userRepository.GetUserByUsernameAndPassword(_loginName, password);
            if (user != null) 
            {
                return new UserDTO
                {
                    LoginName = user.LoginName,
                    FullName = user.FullName,
                 
                };
            } 

            return null; 
        }
    
    }
}
