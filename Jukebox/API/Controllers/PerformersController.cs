using Jukebox.Models.Api;
using Jukebox.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jcm.API.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/performers")]
    public class PerformersController : ControllerBase
    {
        #region Fields/Ctor

        private readonly ILogger<PerformersController> _logger;
        private readonly IPerformerRespository _performerRepository;

        public PerformersController(ILogger<PerformersController> logger,
            IPerformerRespository performerRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _performerRepository = performerRepository ?? 
                throw new ArgumentNullException(nameof(performerRepository));
        }

        #endregion

        #region GET
        /// <summary>
        /// Get list of performers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PerformerDto>>> GetPerformersAsync(
            string searchTerm, int pageNumber = 0, int pageSize = 10)
        {
            var (performerslist, paginationMetadata) = await _performerRepository
                .GetPerformersAsync(searchTerm, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                System.Text.Json.JsonSerializer.Serialize(paginationMetadata));

            return Ok(performerslist);
        }

        /// <summary>
        /// Get performer by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetPerformer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PerformerDto>> GetPerformerByIdAsync(int id)
        {
            var performer = await _performerRepository.GetPerformerAsync(id);

            if (performer == null)
            {
                return NotFound();
            }

            return Ok(performer);
        }

        #endregion

        #region POST
        /// <summary>
        /// Add new performer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PerformerForCreationDto>> AddPerformanceActAsync(
            [FromBody] PerformerForCreationDto dto)
        {
            if (await _performerRepository.PerformerExistsAsync(dto))
            {
                return BadRequest($"The Performer, '{dto.Name}', already exists.  Please choose another name.");
            }

            var createdPerformerToReturn = await _performerRepository.AddPerformerAsync(dto);

            return CreatedAtRoute("GetPerformer",
                new
                {
                    id = createdPerformerToReturn.Id
                },
                createdPerformerToReturn);
        }

        #endregion

        #region PUT
        /// <summary>
        /// Update a performer
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PerformerDto>> UpdatePerformersAsync(
            [FromBody] PerformerForUpdateDto dto)
        {
            if (!await _performerRepository.PerformerExistsAsync(dto.Id))
            {
                return NotFound();
            }

            var createdPerformerToReturn = await _performerRepository.UpdatePerformerAsync(dto);

            return Ok(createdPerformerToReturn);
        }

        #endregion

        #region DELETE
        /// <summary>
        /// Delete a performer
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePerformerAsync(int id)
        {
            var perfomerDto = await _performerRepository.GetPerformerAsync(id);
            if (perfomerDto == null)
                return NotFound();

            await _performerRepository.RemovePerformerAsync(perfomerDto);
            return NoContent();
        }

        #endregion
    }
}