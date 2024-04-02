using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.User
{
    public interface IUserServices
    {
        public Task<UserDTO> GetUserByLoginNameAsync(string _loginName);

        public Task<List<UserDTO>> GetAllUserAsync();

        public Task AddUserAsync(UserDTO userDTO, string facultyID);
        public Task UpdateUserAsync(UserDTO userDTO);
        public Task<UserDTO> UserLogin(string _loginName, string _password);
        public Task<UserDTO> AdminLogin(string _loginname, string _password);
    }
}
