using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcm.DAL.Entities
{
    public class Performer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? LastName { get; set; }

        [ForeignKey(nameof(PerformanceAct))]
        public int PerformanceActId { get; set; }

        public PerformanceAct? PerformanceAct { get; set; }
    }
}
