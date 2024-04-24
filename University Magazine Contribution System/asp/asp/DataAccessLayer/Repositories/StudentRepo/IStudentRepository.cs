using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.StudentRepo
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetStudentByEmailAsync(string email);
        Task<Student> GetStudentWithContributionsByIdAsync(string id);
    }
}
