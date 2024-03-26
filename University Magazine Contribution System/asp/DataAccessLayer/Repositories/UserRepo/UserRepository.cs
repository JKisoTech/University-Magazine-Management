using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.UsersRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly UniMagDbContext _context;

        public UserRepository(UniMagDbContext context)
        {
            _context = context;
        }

        public Models.User GetUserByUsernameAndPassword(string username, string password)
        {


            var user = _context.Users.FirstOrDefault(u => u.LoginName == username);

            if (user != null && VerifyPasswordHash(user.Password, password)) 
            {
                return user;
            }

            return null;
        }

        public async Task<Models.User> GetByIdAsync(string _loginName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.LoginName == _loginName);
        }

        public async Task<List<Models.User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUserAsync(Models.User _user)
        {
            _context.Users.Add(_user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string _loginName)
        {
            var user = await GetByIdAsync(_loginName);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Models.User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public bool ExistUser(string _loginName)
        {
            return _context.Users.Any(u => u.LoginName == _loginName);
        }


        private bool VerifyPasswordHash(string passwordHash, string password)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();

           
            var saltBytes = Convert.FromBase64String(passwordHash.Substring(0, 16));

            
            var passwordWithSalt = Encoding.UTF8.GetBytes(password + Encoding.UTF8.GetString(saltBytes));

            
            var computedHash = hmac.ComputeHash(passwordWithSalt);
            var computedHashBytes = hmac.Key;
            return computedHash.SequenceEqual(Convert.FromBase64String(passwordHash.Substring(16)));
        }
    }
}
