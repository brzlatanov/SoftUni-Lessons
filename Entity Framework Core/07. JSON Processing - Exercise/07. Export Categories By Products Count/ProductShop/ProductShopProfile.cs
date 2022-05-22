﻿using AutoMapper;
using ProductShop.Dtos.Input;
using ProductShop.Dtos.Output;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserInputDto, User>();
            CreateMap<ProductInputDto, Product>();
            CreateMap<CategoryInputDto, Category>();
            CreateMap<CategoryProductInputDto, CategoryProduct>();
            CreateMap<Product, ProductOutputSellerDto>();
            CreateMap<Product, ProductOutputBuyerDto>();
        }
    }
}
