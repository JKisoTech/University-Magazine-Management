using BusinessLogicLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.ContributionService
{
    public interface IContributionServices
    {
        public Task<ContributionsDTO> AddContributionAync(string id, string content, string title, IFormFile type, string description);
        public Task<List<ContributionsDTO>> GetContribution();
        public Task<ContributionsDTO> GetContent(string id);
        public Task SetStatus(string id,int status);
        public Task<ContributionsDTO> UpdateContribution(string id, string content, string title, IFormFile type, string description);
        public Task DeactiveContribution(string id);
      

        public Task<string> WriteFile(IFormFile file);
    }
}
