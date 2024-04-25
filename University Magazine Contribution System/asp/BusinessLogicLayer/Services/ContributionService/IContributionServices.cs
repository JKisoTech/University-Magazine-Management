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
        public Task<IEnumerable<CommentDTO>> GetComment(string id);
        public Task SetStatus(string id,int status);
        public Task<ContributionsDTO> set_Expired();
        public Task<ContributionsDTO> UpdateContribution(string id, string content, string title, IFormFile type, string description);
        public Task<int> check_SubmitDate();
        public Task<int> check_CompleteDate();
        public Task<string> WriteFile(IFormFile file, string id);
        public Task<CommentDTO> SetComment(string user_id, string contributionId, string title, string comment);
        public Task ConvertDocxToPDF(string id);
    }
}
