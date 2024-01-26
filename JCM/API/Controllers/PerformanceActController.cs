using Microsoft.AspNetCore.Mvc;
using Jcm.DAL;
using Jcm.Models.Api;

namespace Jcm.API.Controllers
{
    [ApiController]
    [Route("Act")]
    public class PerformanceActController : ControllerBase
    {

        private readonly ILogger<PerformanceActController> _logger;

        public PerformanceActController(ILogger<PerformanceActController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PerformanceAct>> GetPerformanceActs()
        {
            var list = PerformanceActDataStore.Current.PerformanceActs.ToList();
            return Ok(list);
        }
    }
}