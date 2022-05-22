using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetStore.Data;
using PetStore.Models;
using PetStore.Services.Interfaces;
using PetStore.Services.Models.Product;

namespace PetStore.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly PetStoreDbContext dbContext;
        public ProductService(IMapper mapper, PetStoreDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public ICollection<ListAllProductsServiceModel> GetAllProducts(string order)
        {
            ICollection<ListAllProductsServiceModel> allProducts;

            if (order.ToLower() == "descending")
            {
                allProducts = this.dbContext
                    .Products
                    .ProjectTo<ListAllProductsServiceModel>(this.mapper.ConfigurationProvider)
                    .OrderByDescending(p=> p.Price)
                    .ToArray();
            }
            else
            {
                allProducts = this.dbContext
                    .Products
                    .ProjectTo<ListAllProductsServiceModel>(this.mapper.ConfigurationProvider)
                    .OrderBy(p => p.Price)
                    .ToArray();
            }

            return allProducts;
        }

        public ICollection<ListAllProductsServiceModel> GetAllProductsBySearch(string searchQuery)
            => this.dbContext
                .Products
                .Where(p => p.Name.ToLower().Contains(searchQuery.ToLower()))
                .ProjectTo<ListAllProductsServiceModel>(this.mapper.ConfigurationProvider)
                .OrderBy(p => p.Price)
                .ToArray();


    }
}
