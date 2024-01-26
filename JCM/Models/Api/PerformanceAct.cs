using System.ComponentModel.DataAnnotations;

namespace Jcm.Models.Api
{
    /// <summary>
    /// Dto for a performance act or group
    /// </summary>
    public class PerformanceAct
    {
        /// <summary>
        /// The id of the performer act or group
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the performer act or group
        /// </summary>
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The performers in this act or group
        /// </summary>
        public IEnumerable<Performer> Performers { get; set; }
            = new List<Performer>();
    }
}
