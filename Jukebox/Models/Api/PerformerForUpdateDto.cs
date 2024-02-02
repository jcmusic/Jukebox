namespace Jukebox.Models.Api
{
    /// <summary>
    /// Dto for updating a performer or group
    /// </summary>
    public class PerformerForUpdateDto
    {
        /// <summary>
        /// The id of the performer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the performer
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
