using System.Collections.Generic;
using ProductShop.Models;

namespace ProductShop.Dtos.Output
{
    public class UserWithSoldProductsOutputDto
    {
        public UserWithSoldProductsOutputDto()
        {
            this.soldProducts = new List<ProductOutputBuyerDto>();
        }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public ICollection<ProductOutputBuyerDto> soldProducts { get; set; }
    }
}