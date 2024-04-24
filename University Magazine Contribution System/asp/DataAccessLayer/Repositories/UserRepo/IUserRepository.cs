using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.User
{
    public interface IUserRepository
    {
        public Task<Models.User> GetUserByUsernameAndPassword(string username, string password);
        public Task<Models.User> GetByIdAsync(string _loginName);

        public Task<List<Models.User>> GetUsersAsync();

        public Task AddUserAsync(Models.User user, string facultyID);
        public Task DeleteAsync(string _loginName);
        public Task UpdateAsync(Models.User user);
        public Task<Models.User> SetStatus(string _loginName, bool status);
        public bool ExistUser(string _loginName);
        public string VerifyPasswordHash(string password);
        public Task<bool> VerifyPass(string _password, string hashPass);

    }
}

