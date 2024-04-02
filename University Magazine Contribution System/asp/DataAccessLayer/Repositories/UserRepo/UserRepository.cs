using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.User;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DataAccessLayer.Repositories.UsersRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly UniMagDbContext _context;

        public UserRepository(UniMagDbContext context)
        {
            _context = context;
        }

        public Task<Models.User> GetUserByUsernameAndPassword(string username, string password)
        {

            var users = _context.Users.Where(u => u.LoginName == username && u.Password == password).FirstOrDefaultAsync();
            return users;
        }

        public async Task<Models.User> GetByIdAsync(string _loginName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.LoginName == _loginName);
        }

        public async Task<List<Models.User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUserAsync(Models.User _user, string facultyID)
        {
            _context.Users.Add(_user);

            if (_user.Role == 1)
            {
                var userFaculty = new User_Faculty
                {
                    LoginName = _user.LoginName,
                    FacultyId = facultyID
                };

                _context.user_Faculties.Add(userFaculty);
            }
            else if (_user.Role == 2)
            {
                var userFacultyList = facultyID.Select(facultyId => new User_Faculty
                {
                    LoginName = _user.LoginName,
                    FacultyId = facultyId.ToString()
                });

                _context.user_Faculties.AddRange(userFacultyList);
            }

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
        public string VerifyPasswordHash(string password)
        {
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hashString;
            }
        }
       


    }
}
