using System.Collections;
using System.Collections.Generic;
using PetStore.Models;
using PetStore.Services.Models.Product;

namespace PetStore.Services.Interfaces
{
    public interface IProductService
    {
        ICollection<ListAllProductsServiceModel> GetAllProducts(string order);
        ICollection<ListAllProductsServiceModel> GetAllProductsBySearch(string searchQuery);
    }
}