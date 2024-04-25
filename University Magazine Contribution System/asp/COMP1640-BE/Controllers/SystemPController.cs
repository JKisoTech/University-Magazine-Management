using BusinessLogicLayer.Services.SystemService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemPController : ControllerBase
    {
        private readonly ISystemPServices _systempServices;

        public SystemPController(ISystemPServices systemServices)
        {
            _systempServices = systemServices;
        }

        [HttpGet("Get Submit Date")]
        public async Task<ActionResult> Get_SubmitDate(string name)
        {
            var systemP = await _systempServices.Get_Parameter(name);
            return Ok(systemP);
        }

        [HttpGet("Get Complete Date")]
        public async Task<ActionResult> Get_CompleteDate(string name)
        {
            var systemP = await _systempServices.Get_Parameter(name);
            return Ok(systemP);
        }

        [HttpGet("Dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var data = await _systempServices.Dashboard();

            return Ok(data);
        }        
        [HttpGet("Report")]
        public async Task<IActionResult> ReportData()
        {
            var data = await _systempServices.GetReportData();

            return Ok(data);
        }
        [HttpGet("Report Without Comment Within 14 days")]
        public async Task<IActionResult> ReportDataWithoutComment()
        {
            var data = await _systempServices.GetContributionsWithoutCommentsReport();

            return Ok(data);
        }
    }
}
