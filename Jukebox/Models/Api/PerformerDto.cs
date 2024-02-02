namespace Jukebox.Models.Api
{
    /// <summary>
    /// Dto for a performer or group
    /// </summary>
    public class PerformerDto
    {
        /// <summary>
        /// The id of the performer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the performer
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The name of the performer
        /// </summary>
        public IEnumerable<SongDto> Songs { get; set; } = new List<SongDto>();
    }
}
