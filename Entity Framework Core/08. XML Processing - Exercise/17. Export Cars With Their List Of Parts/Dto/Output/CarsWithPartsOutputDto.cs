using System.Collections.Generic;
using System.Xml.Serialization;
using CarDealer.Dto.Input;

namespace CarDealer.Dto.Output
{
    [XmlType("car")]
    public class CarsWithPartsOutputDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
        [XmlArray("parts")]
        public List<CarPartOutputDto> Parts { get; set; }
    }
}