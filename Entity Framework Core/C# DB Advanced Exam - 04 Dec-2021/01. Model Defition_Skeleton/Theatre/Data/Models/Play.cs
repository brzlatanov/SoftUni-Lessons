using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            this.Casts = new HashSet<Cast>();
            this.Tickets = new HashSet<Ticket>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = @"{hh:mm:ss}")]
        [Range(typeof(TimeSpan), "01:00:00", "10675199.02:48:05.4775807")]
        public TimeSpan Duration { get; set; }
        [Range(0.00, 10.00)]
        public float Rating { get; set; }

        public Genre Genre { get; set; }
        [Required]
        [MaxLength(700)]
        public string Description { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; }
        public ICollection<Cast> Casts { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}