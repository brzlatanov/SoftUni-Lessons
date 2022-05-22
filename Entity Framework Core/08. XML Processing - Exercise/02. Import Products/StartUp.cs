using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //
            //string usersInputString = File.ReadAllText("Datasets/users.xml");
            string productsInputString = File.ReadAllText("../../../Datasets/products.xml");
            //ImportUsers(context, usersInputString);
            ImportProducts(context, productsInputString);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(UserInputDto[]), new XmlRootAttribute("Users"));

            UserInputDto[] deserializedUserInputDtos;

            using (var reader = new StringReader(inputXml))
            {
                deserializedUserInputDtos =
                    (UserInputDto[])serializer.Deserialize(reader);
            }

            var mapper = InitializeMapperWithProductShopProfile();

            User[] users = mapper.Map<User[]>(deserializedUserInputDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {

            var serializer = new XmlSerializer(typeof(ProductInputDto[]), new XmlRootAttribute("Products"));
            
            ProductInputDto[] deserializedProductInputDtos;
            
            using (var reader = new StringReader(inputXml))
            {
                deserializedProductInputDtos =
                    (ProductInputDto[]) serializer.Deserialize(reader);
            }
            
            var mapper = InitializeMapperWithProductShopProfile();
            
            Product[] products = mapper.Map<Product[]>(deserializedProductInputDtos);
            
            context.Products.AddRange(products);
            context.SaveChanges();
            
            return $"Successfully imported {products.Length}";
        }

        private static IMapper InitializeMapperWithProductShopProfile()

        {
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); });

            Mapper mapper = new Mapper(configuration);

            return mapper;
        }
    }
}

    
