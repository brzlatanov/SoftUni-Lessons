using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var inputUsersAsString = File.ReadAllText("../../../Datasets/users.json");
            var inputProductsAsString = File.ReadAllText("../../../Datasets/products.json");

            ImportUsers(dbContext, inputUsersAsString);
            ImportProducts(dbContext, inputProductsAsString);

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            UserInputDto[] userInputDtos = JsonConvert.DeserializeObject<UserInputDto[]>(inputJson);

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = new Mapper(mapperConfiguration);

            User[] users = mapper.Map<User[]>(userInputDtos);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ProductInputDto[] productInputDtos = JsonConvert.DeserializeObject<ProductInputDto[]>(inputJson);

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = new Mapper(mapperConfiguration);

            Product[] products = mapper.Map<Product[]>(productInputDtos);

            context.Products.AddRange(products);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static User MapUser(UserInputDto userDto) //Manual mapping
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