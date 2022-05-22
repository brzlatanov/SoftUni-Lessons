using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Album
    {
        private decimal price;
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(40)]
        [Required]
        public string Name { get; set; }
       
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public decimal Price
        { get; set; }
        [ForeignKey("Producer")]
        public int? ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}