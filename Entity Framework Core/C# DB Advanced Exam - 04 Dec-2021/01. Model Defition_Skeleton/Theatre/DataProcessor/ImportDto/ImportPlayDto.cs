using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }
        [XmlElement("Duration")]
        [Required]
        //[DisplayFormat(DataFormatString = @"hh:mm:ss")]
        //[Range(typeof(TimeSpan), "01:00:00", "10675199.02:48:05.4775807")]
        public string Duration { get; set; }
        [XmlElement("Rating")]
        [Range(0.00, 10.00)]
        public float Rating { get; set; }
        [XmlElement("Genre")]
        public string Genre { get; set; }
        [XmlElement("Description")]
        [Required]
        [MaxLength(700)]
        public string Description { get; set; }
        [XmlElement("Screenwriter")]
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; }
    }

    //<Title>The Hsdfoming</Title>
    //<Duration>03:40:00</Duration>
    //<Rating>8.2</Rating>
    //<Genre>Action</Genre>
    //<Description>A guyat Pinter turns into a debatable conundrum as oth ordinary and menacing. Much of this has to do with the fabled "Pinter Pause," which simply mirrors the way we often respond to each other in conversation, tossing in remainders of thoughts on one subject well after having moved on to another.</Description>
    //<Screenwriter>Roger Nciotti</Screenwriter>
}