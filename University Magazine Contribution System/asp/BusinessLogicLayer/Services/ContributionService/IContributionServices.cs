using BusinessLogicLayer.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.ContributionService
{
    public interface IContributionServices
    {
        public Task AddContributionAync(ContributionsDTO contributionsDTO);
        public Task<List<ContributionsDTO>> GetContribution();
        public Task<ContributionsDTO> GetContent(string id);
        public Task SetStatus(string id,int status);
        public Task<ContributionsDTO> UpdateContribution(string id, string content, string title, string type, string description);
        public Task DeactiveContribution(ContributionsDTO contributionsDTO);
        public Task<string> UpdateImageStorageAsync(string temporaryImagePath);
        public Task<string> SaveImageAsync(IFormFile imageFile);
    }
}
