using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.StudentRepo
{
    public class StudentRepository : IRepository<Student>, IStudentRepository
    {
        private readonly UniMagDbContext _uniMagDbContext;

        public StudentRepository(UniMagDbContext uniMagDbContext)
        {
            _uniMagDbContext = uniMagDbContext;
        }

        public async Task AddAsync(Student student)
        {
            _uniMagDbContext.Students.Add(student);
            await _uniMagDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await GetbyIDAsync(id);
            if (student != null)
            {
                _uniMagDbContext.Students.Remove(student);
                await _uniMagDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _uniMagDbContext.Students.ToListAsync();
        }


        public async Task<Student> GetbyIDAsync(int id)
        {
            return await _uniMagDbContext.Students.FirstOrDefaultAsync(u => u.StudentID == id);
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _uniMagDbContext.Set<Student>()
                .FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Student> GetStudentWithContributionsByIdAsync(int id)
        {
            return await _uniMagDbContext.Students.Include(s => s.Contributions).FirstOrDefaultAsync(c => c.StudentID == id);
        }

        public async Task UpdateAsync(Student student)
        {
            _uniMagDbContext.Students.Update(student);
            await _uniMagDbContext.SaveChangesAsync();
        }
    }
}
