using System.ComponentModel.DataAnnotations;

namespace Jcm.Models.Api
{
    /// <summary>
    /// Dto for a performer or group
    /// </summary>
    public class Performer
    {
        /// <summary>
        /// The id of the performer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the performer
        /// </summary>
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The last name of the performer
        /// </summary>
        [MaxLength(50)]
        public string? LastName { get; set; }
    }
}
