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
        Task<Contribution> AddContributionAsync(string id, string title, string description, string type,string content, int indexNumber, string academy);
        Task<Contribution> GetByIdAsync(string id);
        Task<IEnumerable<Contribution>> GetAllAsync();
        Task<Contribution> UpdateAsync(string id, string title, string description, string type, string content);
        Task<Contribution> SetStatus(string id, int status);

        Task<Comment> SetComment(string user_id, string contributionId, string title,string comment);
        public Task<int> Get_Maxnumber_ID(string studentId);
        public Task<Contribution> SetExpired(string id);
    }
}
