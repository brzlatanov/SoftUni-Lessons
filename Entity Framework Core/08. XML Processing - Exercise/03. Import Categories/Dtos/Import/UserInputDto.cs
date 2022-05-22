using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("user")]
    public class UserInputDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int? Age { get; set; }
    }
}