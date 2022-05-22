using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class SoldProductsOutputDto
    {
        [XmlElement("count")] 
        public int Count { get; set; }
    
        [XmlArray("products")]
        public ProductNamePriceCountOutputDto[] Products { get; set; }
    }
}