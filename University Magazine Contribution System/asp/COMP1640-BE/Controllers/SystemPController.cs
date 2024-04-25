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
            var systemP = await _systempServices.get_submitDate(name);
            return Ok(systemP);
        }

        [HttpGet("Get Complete Date")]
        public async Task<ActionResult> Get_CompleteDate(string name)
        {
            var systemP = await _systempServices.get_completeDate(name);
            return Ok(systemP);
        }
    }
}
