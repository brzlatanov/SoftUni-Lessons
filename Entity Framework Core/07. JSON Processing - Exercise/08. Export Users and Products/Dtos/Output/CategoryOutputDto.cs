using System.Collections.Generic;

namespace ProductShop.Dtos.Output
{
    public class CategoryOutputDto
    {
        public string Name { get; set; }
        //public ICollection<CategoryProductOutputDto> CategoryProducts { get; set; }
        public int ProductCount { get; set; }

        public decimal AveragePrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}