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
        private readonly IContributionServices _contributionServices;

        public ContributionController(IContributionServices contributionServices)
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
        public async Task<ActionResult<IEnumerable<ContributionsDTO>>> GetContributionContent(string Id)
        {
            var contributors = await _contributionServices.GetContent(Id);
            if (contributors == null)
            {
                return NotFound("There is no Contribution with Id: " + Id);
            }
            return Ok(contributors);
        }

        [HttpPost("CreateContributor")]
        public async Task<ActionResult<ContributionsDTO>> SaveContributor([FromBody] ContributionsDTO contributionsDTO)
        {
            await _contributionServices.AddContributionAync(contributionsDTO);
            return StatusCode(201,"User Submit successfully");
        }

        [HttpPut("UpdateContributor")]
        public async Task<ActionResult> UpdateContributor(string id, string content, string title, string type, string description)
        {
            var existingContribution = await _contributionServices.GetContent(id);
            if (existingContribution == null)
            {
                return StatusCode(404, "Contributor Not found");
            }
            await _contributionServices.UpdateContribution( id,  content,  title,  type, description);
            return Ok("Updated");
        }
        
        [HttpPut("UpdateContributorStatus")]
        public async Task<ActionResult> SetStatus(string id, int status)
        {
            
            if (id == null)
            {
                return NoContent();
            }
            await _contributionServices.SetStatus(id, status);
            return Ok(status);
        }
        
        [HttpPut("UpdateContributorComment")]
        public async Task<ActionResult> SetComment(string id, string comment ,[FromBody] ContributionsDTO contributionsDTO)
        {
            
            return StatusCode(204, "Haven't develop Update-Status function");
        }
            
    }
}

