using System.ComponentModel.DataAnnotations;

namespace Jukebox.Models.Api
{
    /// <summary>
    /// Dto for a song
    /// </summary>
    public class SongDto
    {
        /// <summary>
        /// The id of the song
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the song
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Year the song wasa released
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// The number if votes a song has
        /// </summary>
        public int? Votes { get; set; }
    }
}
