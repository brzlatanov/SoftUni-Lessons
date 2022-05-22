using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Dtos.Output;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //var inputUsersAsString = File.ReadAllText("../../../Datasets/users.json");
            //var inputProductsAsString = File.ReadAllText("../../../Datasets/products.json");
            //var inputCategoriesAsString = File.ReadAllText("../../../Datasets/categories.json");
            //var inputCategoriesAndProductsAsString = File.ReadAllText("../../../Datasets/categories-products.json");

            //ImportUsers(dbContext, inputUsersAsString);
            //ImportProducts(dbContext, inputProductsAsString);
            //ImportCategories(dbContext, inputCategoriesAsString);
            //ImportCategoryProducts(dbContext, inputCategoriesAndProductsAsString);
            GetProductsInRange(dbContext);

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            UserInputDto[] userInputDtos = JsonConvert.DeserializeObject<UserInputDto[]>(inputJson);

            var mapper = InitializeAndSetupMapper();

            User[] users = mapper.Map<User[]>(userInputDtos);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ProductInputDto[] productInputDtos = JsonConvert.DeserializeObject<ProductInputDto[]>(inputJson);

            var mapper = InitializeAndSetupMapper();

            Product[] products = mapper.Map<Product[]>(productInputDtos);

            context.Products.AddRange(products);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            CategoryInputDto[] categoryInputDtos = JsonConvert.DeserializeObject<CategoryInputDto[]>(inputJson);

            var mapper = InitializeAndSetupMapper();

            Category[] categories = mapper.Map<Category[]>(categoryInputDtos.Where(c => c.Name != null));

            context.Categories.AddRange(categories);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProductInputDto[] categoriesProductsInputDtos =
                JsonConvert.DeserializeObject<CategoryProductInputDto[]>(inputJson);

            var mapper = InitializeAndSetupMapper();

            CategoryProduct[] categoriesProducts = mapper.Map<CategoryProduct[]>(categoriesProductsInputDtos);

            context.CategoryProducts.AddRange(categoriesProducts);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductOutputDto
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(podto => podto.price)
                .ToArray();

            string productsToString = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText("products-in-range.json", productsToString);

            return productsToString;
        }

        private static IMapper InitializeAndSetupMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); });

            IMapper mapper = new Mapper(mapperConfiguration);
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