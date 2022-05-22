using System.Xml.Serialization;

namespace CarDealer.Dto.Input
{
    [XmlType("partId")]
    public class CarPartInputDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}