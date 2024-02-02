using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.DAL.Entities
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(Performer))]
        public int PerformerId { get; set; }
        public Performer? Performer { get; set; }

        public int? Year { get; set; }

        public int? Votes { get; set; }
    }
}
