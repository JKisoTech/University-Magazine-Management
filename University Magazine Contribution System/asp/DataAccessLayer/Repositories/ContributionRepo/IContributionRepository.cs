using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.ContributionRepo
{
    public interface IContributionRepository
    {
        Task<Contribution> AddContributionAsync(Contribution contribution, string title, string description, string content, string type);
        Task<Contribution> GetByIdAsync(string id);
        Task<IEnumerable<Contribution>> GetAllAsync();
        Task UpdateAsync(Contribution contribution);
        Task DeleteAsync(string id);

    }
}
