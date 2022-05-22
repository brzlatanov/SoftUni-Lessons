using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class UsersAndProductsOutputDto
    {
        [XmlElement("count")]
        public int Count { get; set; } 

        [XmlArray("users")]
        public UsersWithSoldItemsAndAgeDto[] Users { get; set; }
    }
}