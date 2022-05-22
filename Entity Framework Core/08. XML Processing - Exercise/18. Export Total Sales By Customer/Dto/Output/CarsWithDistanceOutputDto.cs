using System.Xml.Serialization;

namespace CarDealer.Dto.Output
{
    [XmlType("car")]
    public class CarsWithDistanceOutputDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}