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
           // context.Database.EnsureDeleted();
           // context.Database.EnsureCreated();
            
           //string usersInputString = File.ReadAllText("Datasets/users.xml");
           //string productsInputString = File.ReadAllText("Datasets/products.xml");
           //string categoriesInputString = File.ReadAllText("Datasets/categories.xml");
           string categoryProductInputString = File.ReadAllText("Datasets/categories-products.xml");
           //ImportUsers(context, usersInputString);
           //ImportProducts(context, productsInputString);
           //ImportCategories(context, categoriesInputString);
            ImportCategoryProducts(context, categoryProductInputString);
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

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoryInputDto[]), new XmlRootAttribute("Categories"));

            CategoryInputDto[] deserializedCategoryInputDtos;

            using (var reader = new StringReader(inputXml))
            {
                deserializedCategoryInputDtos = (CategoryInputDto[]) serializer.Deserialize(reader);
            }

            var mapper = InitializeMapperWithProductShopProfile();

            Category[] categories = mapper.Map<Category[]>(deserializedCategoryInputDtos.Where(d=> d.Name != null));

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer =
                new XmlSerializer(typeof(CategoryProductInputDto[]), new XmlRootAttribute("CategoryProducts"));

            CategoryProductInputDto[] deserializedCategoryProductInputDtos;

            using (var reader = new StringReader(inputXml))
            {
                deserializedCategoryProductInputDtos = (CategoryProductInputDto[]) serializer.Deserialize(reader);
            }

            var mapper = InitializeMapperWithProductShopProfile();

            CategoryProduct[] categoryProducts = mapper.Map<CategoryProduct[]>(deserializedCategoryProductInputDtos.Where(d=> context.Categories.Any(c=> c.Id == d.CategoryId) && context.Products.Any(p=> p.Id == d.ProductId)));

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        private static IMapper InitializeMapperWithProductShopProfile()

        {
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); });

            Mapper mapper = new Mapper(configuration);

            return mapper;
        }
    }
}

    
