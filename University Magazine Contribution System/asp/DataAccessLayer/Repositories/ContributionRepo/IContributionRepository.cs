using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.ContributionRepo
{
    public interface IContributionRepository
    {
        Task<Contribution> AddContributionAsync(Contribution contribution);
        Task<Contribution> GetByIdAsync(int id);
        Task<IEnumerable<Contribution>> GetAllAsync();
        Task UpdateAsync(Contribution contribution);
        Task DeleteAsync(int id);
    }
}
