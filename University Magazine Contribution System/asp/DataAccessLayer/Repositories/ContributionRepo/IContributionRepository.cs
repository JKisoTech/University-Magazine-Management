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
        Task<Contribution> UpdateAsync(string id, string content, string title, string type, string description);
        Task<Contribution> SetStatus(string id, int status);
        Task DeleteAsync(string id);

    }
}
