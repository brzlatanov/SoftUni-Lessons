using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class PlayExportDto
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }
        [XmlAttribute("Duration")]
        public string Duration { get; set; }
        [XmlAttribute("Rating")]
        public string Rating { get; set; }
        [XmlAttribute("Genre")]
        public Genre Genre { get; set; }
        [XmlArray("Actors")]
        public ActorExportDto[] Actors { get; set; }
    }
}