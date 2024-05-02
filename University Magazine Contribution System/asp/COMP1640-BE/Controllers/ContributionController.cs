using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.ContributionService;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.ContributionRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using BusinessLogicLayer.Services.SystemService;

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
        public async Task<ActionResult<ContributionsDTO>> GetContributionContent(string Id)
        {
            var contributors = await _contributionServices.GetContent(Id);
            if (Id != contributors.ContributionID)
            {
                return NotFound("There is no Contribution with Id: " + Id);
            }
            
            await _contributionServices.ConvertDocxToPDF(Id);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "PDFFiles",
                $"{Path.GetFileNameWithoutExtension(contributors.Type)}.pdf");
            if (System.IO.File.Exists(filepath))
            {
                return File(System.IO.File.OpenRead(filepath), "application/pdf");
            }
            return NotFound("PDF not found");
        }
        [HttpGet]
        [Route("GetContribution/{ID}")]

        public async Task<ActionResult<ContributionsDTO>> GetContributionbyID(string ID)
        {
            var contrbution = await _contributionServices.GetContent(ID);
            return Ok(contrbution); 
        }
        
        
        [HttpGet]
        [Route("GetComment/{ID}")]

        public async Task<ActionResult<ContributionsDTO>> GetCommentByID(string ID)
        {
            var contrbution = await _contributionServices.GetComment(ID);
            return Ok(contrbution); 
        }

        [HttpPost("CreateContributor")]
        public async Task<ActionResult<ContributionsDTO>> SaveContributor
            (string user_id,string content, string title, IFormFile type, IFormFile image, string description)
        {
            await _contributionServices.AddContributionAync(user_id,content, title, type, image ,description);
            if (user_id == null)
            {
                return BadRequest();
            }
            await _contributionServices.WriteFile(type, user_id);
            await _contributionServices.SaveImage(image, user_id);
            return StatusCode(201,"User Submit successfully");
        }


        [HttpPut("UpdateContributor")]
        public async Task<ActionResult> UpdateContributor(string id, string content, string title, IFormFile type, IFormFile image, string description)
        {
            var existingContribution = await _contributionServices.GetContent(id);
            if (existingContribution == null)
            {
                return StatusCode(404, "Contributor Not found");
            }
            await _contributionServices.UpdateContribution( id,  content,  title,  type, image,description);
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
        public async Task<ActionResult> SetComment(string _coordinatorId, string _contributionID,string title,string comment)
        {
            var newComment = await _contributionServices.SetComment(_coordinatorId, _contributionID, title, comment);
            if ( _contributionID == null )
            {
                return NotFound("No Contribution Found");
            }

            return Ok(newComment);
            
        }
        
        [HttpPut("Set Expired")]
        public async Task<ActionResult> SetExpired()
        {
            var newComment = await _contributionServices.set_Expired();
            return Ok(newComment);
            
        }

        [HttpGet("Check Submit Date")]
        public async Task<IActionResult> check_SubmitDate()
        {
   
            var submitDate = await _contributionServices.check_SubmitDate();
            return Ok(submitDate);
        }
        [HttpGet("Check PublishDate")]
        public async Task<IActionResult> check_CompleteDate()
        {
    
            var completeDate = await _contributionServices.check_CompleteDate();
  
            return Ok(completeDate);
        }
    }
}

