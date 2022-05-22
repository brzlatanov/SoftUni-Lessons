using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Dtos.Output;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var inputUsersAsString = File.ReadAllText("../../../Datasets/users.json");
            var inputProductsAsString = File.ReadAllText("../../../Datasets/products.json");
            var inputCategoriesAsString = File.ReadAllText("../../../Datasets/categories.json");
            var inputCategoriesAndProductsAsString = File.ReadAllText("../../../Datasets/categories-products.json");

            ImportUsers(dbContext, inputUsersAsString);
            ImportProducts(dbContext, inputProductsAsString);
            ImportCategories(dbContext, inputCategoriesAsString);
            ImportCategoryProducts(dbContext, inputCategoriesAndProductsAsString);
            GetProductsInRange(dbContext);
            GetSoldProducts(dbContext);
            GetCategoriesByProductsCount(dbContext);
            GetUsersWithProducts(dbContext);
            GetUsersWithProducts(dbContext);

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            UserInputDto[] userInputDtos = JsonConvert.DeserializeObject<UserInputDto[]>(inputJson);

            InitializeAndSetupMapper();

            User[] users = mapper.Map<User[]>(userInputDtos);

            context.Users.AddRange(users);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ProductInputDto[] productInputDtos = JsonConvert.DeserializeObject<ProductInputDto[]>(inputJson);

            InitializeAndSetupMapper();

            Product[] products = mapper.Map<Product[]>(productInputDtos);

            context.Products.AddRange(products);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            CategoryInputDto[] categoryInputDtos = JsonConvert.DeserializeObject<CategoryInputDto[]>(inputJson);

            InitializeAndSetupMapper();

            Category[] categories = mapper.Map<Category[]>(categoryInputDtos.Where(c => c.Name != null));

            context.Categories.AddRange(categories);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProductInputDto[] categoriesProductsInputDtos =
                JsonConvert.DeserializeObject<CategoryProductInputDto[]>(inputJson);

            InitializeAndSetupMapper();

            CategoryProduct[] categoriesProducts = mapper.Map<CategoryProduct[]>(categoriesProductsInputDtos);

            context.CategoryProducts.AddRange(categoriesProducts);

            return $"Successfully imported {context.SaveChanges()}";
        }


        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductOutputSellerDto
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(podto => podto.price)
                .ToArray();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string productsToString = JsonConvert.SerializeObject(products, jsonSettings);

            File.WriteAllText("products-in-range.json", productsToString);

            return productsToString;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users.Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserWithSoldProductsOutputDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(c => new ProductOutputBuyerDto
                        {
                            Name = c.Name,
                            Price = c.Price,
                            BuyerFirstName = c.Buyer.FirstName,
                            BuyerLastName = c.Buyer.LastName
                        }).ToList()

                }).ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string usersToString = JsonConvert.SerializeObject(users, jsonSettings);

            File.WriteAllText("users-sold-products.json", usersToString);

            return usersToString;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = (c.CategoryProducts.Sum(cp => cp.Product.Price) / c.CategoryProducts.Count).ToString("F2"),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
                })
                .ToArray();


            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string categoriesToString = JsonConvert.SerializeObject(categories, jsonSettings);

            File.WriteAllText("categories-by-products.json", categoriesToString);

            return categoriesToString;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(b => b.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(x => x.Buyer != null),
                        products = u.ProductsSold.Where(x => x.Buyer != null).Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }
                })
                .OrderByDescending(x => x.soldProducts.products.Count());

            var resultObject = new
            {
                usersCount = users.Count(),
                users = users
            };


            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            string usersWithProductsToString = JsonConvert.SerializeObject(resultObject, jsonSettings);

            File.WriteAllText("users-and-products.json", usersWithProductsToString);

            return usersWithProductsToString;


        }

        private static IMapper InitializeAndSetupMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); });

            mapper = new Mapper(mapperConfiguration);

            return mapper;
        }

        public static User MapUser(UserInputDto userDto) 
        {
            return new User
            {
                Age = userDto.Age,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName
            };
        }
    }
}