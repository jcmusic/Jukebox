using Microsoft.AspNetCore.Mvc;
using Jcm.DAL;
using Jcm.Models.Api;

namespace Jcm.API.Controllers
{
    [ApiController]
    [Route("api/acts")]
    public class PerformanceActController : ControllerBase
    {

        private readonly ILogger<PerformanceActController> _logger;

        public PerformanceActController(ILogger<PerformanceActController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get list of performance acts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PerformanceAct>> GetPerformanceActs()
        {
            var list = PerformanceActDataStore.Current.PerformanceActs.ToList();

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        /// <summary>
        /// Get performance act by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PerformanceAct>> GetPerformanceActs(int id)
        {
            var list = PerformanceActDataStore.Current.PerformanceActs
                .FirstOrDefault(a => a.Id == id);

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }
    }
}