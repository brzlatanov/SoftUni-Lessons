using System;
using AutoMapper;
using PetStore.Models;
using PetStore.Services.Models.Product;

namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ListAllProductsServiceModel>();
        }
    }
}
