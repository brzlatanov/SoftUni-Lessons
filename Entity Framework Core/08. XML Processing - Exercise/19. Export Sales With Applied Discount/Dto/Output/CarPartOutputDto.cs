using System.Xml.Serialization;

namespace CarDealer.Dto.Output
{
    [XmlType("part")]
    public class CarPartOutputDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}