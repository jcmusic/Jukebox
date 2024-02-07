namespace Jukebox.Models.Api
{
    /// <summary>
    /// Dto for a song
    /// </summary>
    public class SongForCreationDto
    {
        /// <summary>
        /// The name of the song
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Year the song was released
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Id of the Performer of this song
        /// </summary>
        public int PerformerId { get; set; }
    }
}
