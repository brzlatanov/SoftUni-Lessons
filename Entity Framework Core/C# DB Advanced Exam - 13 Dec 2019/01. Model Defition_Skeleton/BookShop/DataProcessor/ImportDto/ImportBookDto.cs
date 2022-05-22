using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using BookShop.Data.Models.Enums;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class ImportBookDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        [XmlElement("Genre")]
        [Required]
        public int Genre { get; set; }
        [XmlElement("Price")]
        [Range(0.01, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        [XmlElement("Pages")]
        [Range(50, 5000)]
        public int Pages { get; set; }
        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }
    }
}