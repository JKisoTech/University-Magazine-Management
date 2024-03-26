using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AuthenticateService
{
    public interface IAuthenticationServices
    {
        public UserDTO Authenticate(string _loginName, string password);
    }
}
