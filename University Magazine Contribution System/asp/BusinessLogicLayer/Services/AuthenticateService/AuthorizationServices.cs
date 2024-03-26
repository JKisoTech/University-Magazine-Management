using BusinessLogicLayer.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AuthenticateService
{
    public class AuthorizationServices
    {
        private readonly IDictionary<string, string[]> _authorizationRules;

        public AuthorizationServices(IConfiguration configuration)
        {
            _authorizationRules = configuration.GetSection("AuthorizationRules").Get<Dictionary<string, string[]>>();
        }

        public bool IsAuthorized(UserDTO user, string action)
        {
            if (user == null || !_authorizationRules.ContainsKey(action))
            {
                return false;
            }

            var authorizedRoles = _authorizationRules[action];
            return authorizedRoles.Contains(user.Role.ToString());
        }
    }
}
