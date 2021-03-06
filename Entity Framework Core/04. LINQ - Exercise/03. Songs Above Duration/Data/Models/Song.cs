using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MusicHub.Data.Models.Enums;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        
        [Required]
        public TimeSpan Duration { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public virtual Genre Genre { get; set; }

        [ForeignKey("Album")]
        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }

        [ForeignKey("Writer")]
        [Required]
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
    }
}