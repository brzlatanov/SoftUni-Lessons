using System.Collections.Generic;
using ProductShop.Models;

namespace ProductShop.Dtos.Output
{
    public class UserWithSoldProductsOutputDto
    {
        public UserWithSoldProductsOutputDto()
        {
            this.SoldProducts = new List<ProductOutputBuyerDto>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ICollection<ProductOutputBuyerDto> SoldProducts { get; set; }
    }
}