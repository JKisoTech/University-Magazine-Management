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

        public ContributionController(ContributionServices contributionServices)
        {
            _contributionServices = contributionServices;
        }
 
        [HttpGet("GetContributor")]
        public async Task<ActionResult<IEnumerable<ContributionsDTO>>> getContribution()
        {
            var contributors = await _contributionServices.GetContribution();
            return Ok(contributors);
        }
        
        [HttpGet("GetContent")]
        public async Task<ActionResult<IEnumerable<ContributionsDTO>>> GetContributionContent()
        {
            var contributors = await _contributionServices.GetContribution();
            return Ok(contributors);
        }

        [HttpPost("CreateContributor")]
        public async Task<ActionResult<ContributionsDTO>> SaveContributor([FromBody] ContributionsDTO contributionsDTO)
        {
            await _contributionServices.AddContributionAync(contributionsDTO);
            return Ok();
        }

        [HttpPut("UpdateContributor")]
        public async Task<ActionResult> UpdateContributor(string id, [FromBody] ContributionsDTO contributionsDTO)
        {
            if (id != contributionsDTO.ContributionID)
            {
                return StatusCode(404, "Contributor Not found");
            }
            return StatusCode(204, "Haven't develop Update function");
        }
        
        [HttpPut("UpdateContributorStatus")]
        public async Task<ActionResult> SetStatus(string id, bool status, DateTime dueDate ,[FromBody] ContributionsDTO contributionsDTO)
        {
            
            return StatusCode(204, "Haven't develop Update-Status function");
        }
        
        [HttpPut("UpdateContributorComment")]
        public async Task<ActionResult> SetComment(string id, string comment ,[FromBody] ContributionsDTO contributionsDTO)
        {
            
            return StatusCode(204, "Haven't develop Update-Status function");
        }
            
    }
}

