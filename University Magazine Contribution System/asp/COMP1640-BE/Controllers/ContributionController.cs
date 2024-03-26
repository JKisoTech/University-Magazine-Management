using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.ContributionService;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.ContributionRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionController : ControllerBase
    {
        private readonly ContributionServices _contributionServices;

 
        [HttpGet("GetContributor")]
        public async Task<ActionResult<IEnumerable<ContributionsDTO>>> getContribution()
        {
            var contributors = await _contributionServices.GetContribution();
            return Ok();
        }
        
        [HttpGet("GetContent")]
        public async Task<ActionResult<IEnumerable<ContributionsDTO>>> GetContributionContent()
        {
            var contributors = await _contributionServices.GetContribution();
            return Ok();
        }

        [HttpPost("CreateContributor")]
        public async Task<ActionResult<ContributionsDTO>> SaveContributor([FromBody] ContributionsDTO contributionsDTO)
        {
            return StatusCode(204, "Haven't develop create function");
        }

        [HttpPut("UpdateContributor")]
        public async Task<ActionResult> UpdateContributor(int id, [FromBody] ContributionsDTO contributionsDTO)
        {
            if (id != contributionsDTO.ContributionID)
            {
                return StatusCode(404, "Contributor Not found");
            }
            return StatusCode(204, "Haven't develop Update function");
        }
        
        [HttpPut("UpdateContributorStatus")]
        public async Task<ActionResult> SetStatus(int id, int status, DateTime dueDate ,[FromBody] ContributionsDTO contributionsDTO)
        {
            
            return StatusCode(204, "Haven't develop Update-Status function");
        }
        
        [HttpPut("UpdateContributorComment")]
        public async Task<ActionResult> SetComment(int id, string comment ,[FromBody] ContributionsDTO contributionsDTO)
        {
            
            return StatusCode(204, "Haven't develop Update-Status function");
        }
            
    }
}

