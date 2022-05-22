using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using ProductShop.Data;
using ProductShop.Dtos.Export;
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
            //string productsInputString = File.ReadAllText("Datasets/products.xml");
            //string categoriesInputString = File.ReadAllText("Datasets/categories.xml");
            //string categoryProductInputString = File.ReadAllText("Datasets/categories-products.xml");
            //ImportUsers(context, usersInputString);
            //ImportProducts(context, productsInputString);
            //ImportCategories(context, categoriesInputString);
            //ImportCategoryProducts(context, categoryProductInputString);
            //GetProductsInRange(context);
            //GetSoldProducts(context);
            //GetCategoriesByProductsCount(context);
            GetUsersWithProducts(context);
        }


        public static string GetProductsInRange(ProductShopContext context)
        {
            ProductInRangeOutputDto[] productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductInRangeOutputDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .Take(10)
                .ToArray();

            var writer = new XmlTextWriter("products-in-range.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            var serializer = new XmlSerializer(typeof(ProductInRangeOutputDto[]), new XmlRootAttribute("Products"));

            using (writer)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, productsInRange, ns);
            }

            string returnString = File.ReadAllText("products-in-range.xml");

            return returnString;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithOneSoldItem = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UsersWithOneSoldItemOutputDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps =>
                        new ProductOutputDto
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        }).ToArray()
                })
                .Take(5)
                .ToArray();

            var writer = new XmlTextWriter("users-sold-products.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            var serializer = new XmlSerializer(typeof(UsersWithOneSoldItemOutputDto[]), new XmlRootAttribute("Users"));

            using (writer)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, usersWithOneSoldItem, ns);
            }

            string returnString = File.ReadAllText("users-sold-products.xml");

            return returnString;

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoryOutputDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var writer = new XmlTextWriter("categories-by-products.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            var serializer = new XmlSerializer(typeof(CategoryOutputDto[]), new XmlRootAttribute("Categories"));

            using (writer)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, categories, ns);
            }

            string returnString = File.ReadAllText("categories-by-products.xml");

            return returnString;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var users = new UsersAndProductsOutputDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = context.Users.Where(x => x.ProductsSold.Any())
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .Select(y => new UsersWithSoldItemsAndAgeDto
                    {
                        FirstName = y.FirstName,
                        LastName = y.LastName,
                        Age = y.Age,
                        SoldProducts = new SoldProductsOutputDto
                        {
                            Count = y.ProductsSold.Count,
                            Products = y.ProductsSold.Select(v => new ProductNamePriceCountOutputDto
                            {
                                Name = v.Name,
                                Price = v.Price
                            }).ToArray()
                        }
                    }).ToArray()
            };

            var writer = new XmlTextWriter("users-and-products.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            var serializer = new XmlSerializer(typeof(UsersAndProductsOutputDto), new XmlRootAttribute("Users"));

            using (writer)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, users, ns);
            }

            string returnString = File.ReadAllText("users-and-products.xml");

            return returnString;
        }

        private static IMapper InitializeMapperWithProductShopProfile()

        {
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); });

            Mapper mapper = new Mapper(configuration);

            return mapper;
        }
    }
}


