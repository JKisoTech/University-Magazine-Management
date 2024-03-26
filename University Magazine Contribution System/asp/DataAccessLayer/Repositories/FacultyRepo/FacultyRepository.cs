using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.FacultyRepo
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly UniMagDbContext _context;

        public FacultyRepository(UniMagDbContext context)
        {
            _context = context;
        }

        public async Task<Faculty> GetByIdAsync(int id)
        {
            return await _context.faculty.FirstOrDefaultAsync(u => u.FacultyID == id);
        }

        public async Task<List<Faculty>> GetFacultyAsync()
        {
            return await _context.faculty.ToListAsync();
        }

        public async Task AddFacultyAsync(Faculty faculty)
        {
            _context.faculty.Add(faculty);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFacultyAsync(int id)
        {
            var faculty = await GetByIdAsync(id);
            if (faculty != null)
            {
                _context.faculty.Remove(faculty);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateFacultyAsync(Faculty faculty)
        {
            _context.faculty.Update(faculty);
            await _context.SaveChangesAsync();
        }
    }
}
