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
        public Models.User GetUserByUsernameAndPassword(string username, string password);
        public Task<Models.User> GetByIdAsync(string _loginName);

        public Task<List<Models.User>> GetUsersAsync();

        public Task AddUserAsync(Models.User user);
        public Task DeleteAsync(string _loginName);
        public Task UpdateAsync(Models.User user);
        public bool ExistUser(string _loginName);


    }
}

