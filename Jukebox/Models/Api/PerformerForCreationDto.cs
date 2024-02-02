using System.ComponentModel.DataAnnotations;

namespace Jukebox.Models.Api
{
    /// <summary>
    /// Dto for a performer, or band
    /// </summary>
    public class PerformerForCreationDto
    {
        /// <summary>
        /// The name of the performer/band
        /// </summary>
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
