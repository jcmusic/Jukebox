using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.DAL.Entities
{
    public class Performer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Song> Songs { get; set; } = new List<Song>();

        //[Required]
        //public int CreatedBy { get; set; }  // todo  

        //[Required]
        //[ForeignKey(nameof(PerformanceAct))]
        //public int UserId { get; set; }  // todo
        //public User User { get; set; }  // todo
    }
}
