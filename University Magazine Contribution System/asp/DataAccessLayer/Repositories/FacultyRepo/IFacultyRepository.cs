using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.FacultyRepo
{
    public interface IFacultyRepository
    {
        public Task<Faculty> GetByIdAsync(string id);
        public Task<List<Faculty>> GetFacultyAsync();
        public Task AddFacultyAsync(Faculty faculty);
        public Task DeleteFacultyAsync(string id);
        public Task<IEnumerable<Contribution>> GetContributionsByFacultyId(string facultyId);
        public Task UpdateFacultyAsync(Faculty faculty);
    }
}
