using System.Runtime.CompilerServices;
using ProductShop.Models;

namespace ProductShop.Dtos.Output
{
    public class ProductOutputSellerDto
    {
        public string name { get; set; }

        public decimal price { get; set; }

        public string seller { get; set; } 
    }
}