using System.Xml.Serialization;

namespace CarDealer.Dto.Input
{
    [XmlType("Supplier")]
    public class SupplierInputDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}