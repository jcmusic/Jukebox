using Jukebox.BLL.Interfaces;
using Jukebox.Models.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jcm.API.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/songs")]
    public class SongsController : ControllerBase
    {
        #region Fields/Ctor

        private readonly ILogger<SongsController> _logger;
        private readonly ISongRepository _songRepository;

        public SongsController(ILogger<SongsController> logger,
            ISongRepository songRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _songRepository = songRepository ?? 
                throw new ArgumentNullException(nameof(songRepository));
        }

        #endregion

        #region GET

        /// <summary>
        /// Get list of songs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SongDto>>> GetSongsAsync(
            int pageNumber = 0, int pageSize = 10)
        {
            var list = await _songRepository
                .GetSongsAsync(pageNumber, pageSize);

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        /// <summary>
        /// Get songs by performer id
        /// </summary>
        /// <returns></returns>
        [HttpGet("performers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PerformerDto>> GetSongsByPerformerIdAsync(
            int id, int pageNumber, int pageSize)
        {
            var songlist = await _songRepository.GetSongsByPerformerIdAsync(id, pageNumber, pageSize);

            return Ok(songlist);
        }

        /// <summary>
        /// Get song by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSong")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PerformerDto>> GetSongByIdAsync(int id)
        {
            var song = await _songRepository.GetSongAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        #endregion

        //#region POST
        ///// <summary>
        ///// Add new song
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("performers")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<ActionResult<PerformerForCreationDto>> AddPerformanceActAsync(
        //    [FromBody] PerformerForCreationDto dto)
        //{
        //    if (await _songRepository.PerformerExistsAsync(dto))
        //    {
        //        return BadRequest($"The Performance Act {dto.Name} already exists.  Please choose another name.");
        //    }

        //    var createdPerformerToReturn = await _songRepository.AddPerformerAsync(dto);

        //    return CreatedAtRoute("GetPerformanceAct",
        //        new
        //        {
        //            id = createdPerformerToReturn.Id
        //        },
        //        createdPerformerToReturn);
        //}

        //#endregion

        #region PUT
        /// <summary>
        /// Update a song
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<SongDto>> UpdateSongAsync(
            [FromBody] SongForUpdateDto dto)
        {
            if (await _songRepository.SongExistsAsync(dto.Id))
            {
                return NotFound();
            }

            var createdSongToReturn = await _songRepository.UpdateSongAsync(dto);

            return Ok(createdSongToReturn);
        }

        #endregion

        #region DELETE
        /// <summary>
        /// Delete a song
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePerformerAsync(
            int id)
        {
            var songDto = await _songRepository.GetSongAsync(id);
            if (songDto == null)
                return NotFound();

            await _songRepository.RemoveSong(id);
            return NoContent();
        }

        #endregion
    }
}