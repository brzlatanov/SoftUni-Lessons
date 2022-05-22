using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dto.Output;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //
            //string inputSuppliers = File.ReadAllText("Datasets/suppliers.xml");
            //string inputParts = File.ReadAllText("Datasets/parts.xml");
            //string inputCars = File.ReadAllText("Datasets/cars.xml");
            //string inputCustomers = File.ReadAllText("Datasets/customers.xml");
            //string inputSales = File.ReadAllText("Datasets/sales.xml");
            //ImportSuppliers(context, inputSuppliers);
            //ImportParts(context, inputParts);
            //ImportCars(context, inputCars);
            //ImportCustomers(context, inputCustomers);
            //ImportSales(context, inputSales);
            //GetCarsWithDistance(context);
            //GetCarsFromMakeBmw(context);
            //GetLocalSuppliers(context);
            //GetCarsWithTheirListOfParts(context);
            //GetTotalSalesByCustomer(context);
            GetSalesWithAppliedDiscount(context);
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new CarsWithDistanceOutputDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            XmlSerializer serializer = InitializeXmlSerializer(typeof(CarsWithDistanceOutputDto[]), "cars");

            var writer = new XmlTextWriter("cars.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            using (writer)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, cars, ns);
            }

            string returnString = File.ReadAllText("cars.xml");

            return returnString;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.Make == "BMW")
                .Select(c => new CarsIdModelTraveledDistanceOutputDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            XmlSerializer serializer = InitializeXmlSerializer(typeof(CarsIdModelTraveledDistanceOutputDto[]), "cars");

            var writer = new XmlTextWriter("bmw-cars.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            using (writer)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, cars, ns);
            }

            string returnString = File.ReadAllText("bmw-cars.xml");

            return returnString;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new SuppliersOutputDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            XmlSerializer serializer = InitializeXmlSerializer(typeof(SuppliersOutputDto[]), "suppliers");

            var writer = new XmlTextWriter("local-suppliers.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            using (writer)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, suppliers, ns);
            }

            string returnString = File.ReadAllText("local-suppliers.xml");

            return returnString;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarsWithPartsOutputDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new CarPartOutputDto
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        }).OrderByDescending(p => p.Price)
                        .ToList()
                }).OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            XmlSerializer serializer = InitializeXmlSerializer(typeof(List<CarsWithPartsOutputDto>), "cars");

            var writer = new XmlTextWriter("cars-and-parts.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            using (writer)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, cars, ns);
            }

            string returnString = File.ReadAllText("cars-and-parts.xml");

            return returnString;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new CustomerTotalSalesOutputDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Select(s => s.Car).SelectMany(s => s.PartCars).Sum(s => s.Part.Price)
                }).OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer serializer = InitializeXmlSerializer(typeof(CustomerTotalSalesOutputDto[]), "customers");

            var writer = new XmlTextWriter("customers-total-sales.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            using (writer)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, customers, ns);
            }

            string returnString = File.ReadAllText("customers-total-sales.xml");

            return returnString;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SalesOutputDto
                {
                    Car = new CarOutputDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100
                })
                .ToArray();

            XmlSerializer serializer = InitializeXmlSerializer(typeof(SalesOutputDto[]), "sales");

            var writer = new XmlTextWriter("sales-discounts.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            using (writer)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, sales, ns);
            }

            string returnString = File.ReadAllText("sales-discounts.xml");

            return returnString;
        }

        private static XmlSerializer InitializeXmlSerializer(Type type, string rootElement)
        {
            XmlSerializer serializer = new XmlSerializer((type), new XmlRootAttribute(rootElement));
            return serializer;
        }

        private static IMapper InitializeMapperWithCarDealerProfile()
        {
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); });

            Mapper mapper = new Mapper(configuration);

            return mapper;
        }
    }
}