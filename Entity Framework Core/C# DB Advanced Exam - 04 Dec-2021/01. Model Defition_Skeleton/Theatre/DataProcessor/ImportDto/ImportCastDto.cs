﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastDto
    {
        [XmlElement("FullName")]
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName { get; set; }
        [XmlElement("IsMainCharacter")]
        public bool IsMainCharacter { get; set; }
        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(@"^\+44-\d{2}-\d{3}-\d{4}$")]
        public string PhoneNumber { get; set; }
        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}