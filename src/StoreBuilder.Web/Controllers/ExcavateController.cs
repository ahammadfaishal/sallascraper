using Microsoft.AspNetCore.Mvc;
using StoreBuilder.Core.Excavation;

namespace StoreBuilder.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExcavateController : ControllerBase
    {
        private readonly IExcavationService _excavationService;

        public ExcavateController(IExcavationService excavationService)
        {
            _excavationService = excavationService;
        }

        [HttpGet]
        public async Task<ActionResult> InitJob(string targetSiteurl)
        {
            await _excavationService.CollectData(targetSiteurl);
            return Ok("Hello World!");
        }
    }
}
