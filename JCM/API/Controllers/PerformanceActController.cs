using Jcm.BLL.Interfaces;
using Jcm.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace Jcm.API.Controllers
{
    [ApiController]
    [Route("api/acts")]
    public class PerformanceActController : ControllerBase
    {

        private readonly ILogger<PerformanceActController> _logger;
        private readonly IPerformanceActReposity _performanceActRepository;

        public PerformanceActController(ILogger<PerformanceActController> logger,
            IPerformanceActReposity performanceActRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _performanceActRepository = performanceActRepository ?? 
                throw new ArgumentNullException(nameof(performanceActRepository));
        }

        /// <summary>
        /// Get list of performance acts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PerformanceActDto>>> GetPerformanceActsAsync(
            int pageNumber = 0, int pageSize = 10, bool includePerformers = false)
        {
            var list = await _performanceActRepository
                .GetPerformanceActsAsync(pageNumber, pageSize, includePerformers);

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
        public async Task<ActionResult<PerformanceActDto>> GetPerformanceActAsync(
            int id, bool includePerformers = false)
        {
            var act = await _performanceActRepository.GetPerformanceActAsync(id, includePerformers);

            if (act == null)
            {
                return NotFound();
            }

            return Ok(act);
        }
    }
}