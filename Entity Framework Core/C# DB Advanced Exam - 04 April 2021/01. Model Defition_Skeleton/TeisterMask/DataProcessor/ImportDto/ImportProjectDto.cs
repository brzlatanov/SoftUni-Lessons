using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(CommonConstants.PROJECT_NAME_MIN_LENGTH)]
        [MaxLength(CommonConstants.PROJECT_NAME_MAX_LENGTH)]
        public string Name { get; set; }
        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }
        [XmlElement("DueDate")]
        public string DueDate { get; set; }
        [XmlArray("Tasks")]
        public ImportTaskDto[] Tasks { get; set; }
    
    }
}