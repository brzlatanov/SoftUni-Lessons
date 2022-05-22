using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [ForeignKey("Song")]
        public int SongId { get; set; }
        [Required]
        public Song Song { get; set; }

        [ForeignKey("Performer")]
        public int PerformerId { get; set; }
        [Required]
        public Performer Performer { get; set; }
    }
}