using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SystemRepo
{
    public class SystemPRepository : ISystemPRepository
    {
        private readonly UniMagDbContext _context;

        public SystemPRepository(UniMagDbContext context)
        {
            _context = context;
        }
        public async Task<SystemParameter> Get_Parameter(string parameterName)
        {
            return _context.systemParameters.FirstOrDefault(p => p.Name == parameterName);
        }

        public async Task<Dictionary<string, int>> Dashboard()
        {
            var totalContributions = await _context.contributions.CountAsync();

            var facultyContributions = await _context.contributions
                 .Where(c => c.Status == 3) // Filter by Contribution Status 
                 .Join(_context.faculty, // Join with the Faculty table
                     c => c.student.FacultyID,
                     f => f.FacultyID,
                     (c, f) => new // Project to an anonymous type with both entities
                     {
                         Contribution = c,
                         Faculty = f
                     })
                 .GroupBy(cf => cf.Faculty) // Group by Faculty entity from the join
                 .Select(group => new // Project a new anonymous type
                 {
                     Faculty = group.Key.FacultyName, // Access FacultyName from the Faculty entity
                     NumOfC = group.Count() // Count contributions within each group
                 })
                 .ToListAsync();

            var result = new Dictionary<string, int>
            {
                { "TotalContributions", totalContributions }
            };

            if (facultyContributions != null && facultyContributions.Any())
            {
                foreach (var fc in facultyContributions)
                {
                    result.Add($"NumOfC_{fc.Faculty}", fc.NumOfC);
                }
            }

            return result;
        }
    }
}
