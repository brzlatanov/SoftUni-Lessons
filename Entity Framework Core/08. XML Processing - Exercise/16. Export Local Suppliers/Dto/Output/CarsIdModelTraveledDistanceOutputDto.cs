using System.Xml.Serialization;

namespace CarDealer.Dto.Output
{
    [XmlType("car")]
    public class CarsIdModelTraveledDistanceOutputDto
    {
        [XmlAttribute("id")] 
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}