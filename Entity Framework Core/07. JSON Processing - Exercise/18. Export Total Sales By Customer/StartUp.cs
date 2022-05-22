using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.Models;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext(new DbContextOptions<CarDealerContext>());
           // context.Database.EnsureDeleted();
           // context.Database.EnsureCreated();
           //
           // string inputSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
           // string inputParts = File.ReadAllText("../../../Datasets/parts.json");
           // string inputCars = File.ReadAllText("../../../Datasets/cars.json");
           // string inputCustomers = File.ReadAllText("../../../Datasets/customers.json");
            string inputSales = File.ReadAllText("../../../Datasets/sales.json");

           //ImportSuppliers(context, inputSuppliers);
           //ImportParts(context, inputParts);
           //ImportCars(context, inputCars);
           //ImportCustomers(context, inputCustomers);
           //ImportSales(context, inputSales);
           //GetOrderedCustomers(context);
           //GetCarsFromMakeToyota(context);
           //GetLocalSuppliers(context);
           //GetCarsWithTheirListOfParts(context);
           GetTotalSalesByCustomer(context);
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {

            var supplierDtos = JsonConvert.DeserializeObject<SupplierInputDto[]>(inputJson);

            var mapper = InitializeAndSetupMapper();

            var suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);

            return $"Successfully imported {context.SaveChanges()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var partDtos = JsonConvert.DeserializeObject<PartInputDto[]>(inputJson);

            var mapper = InitializeAndSetupMapper();

            var parts = mapper.Map<Part[]>(partDtos.Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId)));

            context.Parts.AddRange(parts);

            return $"Successfully imported {context.SaveChanges()}.";
        }



        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            IEnumerable<CarInputDto> carsDto = JsonConvert.DeserializeObject<IEnumerable<CarInputDto>>(inputJson);

            var carList = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                carList.Add(currentCar);
            }

            context.Cars.AddRange(carList);
            context.SaveChanges();
            return $"Successfully imported {carList.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDto = JsonConvert.DeserializeObject<CustomerInputDto[]>(inputJson);

            var mapper = InitializeAndSetupMapper();

            var customers = mapper.Map<Customer[]>(customersDto);

            context.Customers.AddRange(customers);

            return $"Successfully imported {context.SaveChanges()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var saleDto = JsonConvert.DeserializeObject<SaleInputDto[]>(inputJson);

            var mapper = InitializeAndSetupMapper();

            var sales = mapper.Map<Sale[]>(saleDto);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c=> new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                });

            var customersToString = JsonConvert.SerializeObject(customers, Formatting.Indented);

            File.WriteAllText("ordered-customers.json", customersToString);

            return customersToString;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {

            string make = "Toyota";

            var cars = context.Cars
                .Where(c=> c.Make == make)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToArray();

            string carsToString = JsonConvert.SerializeObject(cars, Formatting.Indented);

            File.WriteAllText("toyota-cars.json", carsToString);

            return carsToString;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            string localSuppliersToString = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

            File.WriteAllText("local-suppliers.json", localSuppliersToString);

            return localSuppliersToString;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("F2")
                    }).ToArray()
                }).ToArray();

            string carsToString = JsonConvert.SerializeObject(cars, Formatting.Indented);

            File.WriteAllText("cars-and-parts.json", carsToString);

            return carsToString;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c=> c.spentMoney)
                .ThenByDescending(c=> c.boughtCars)
                .ToArray();

            string customersToString = JsonConvert.SerializeObject(customers, Formatting.Indented);

            File.WriteAllText("customers-total-sales.json", customersToString);

            return customersToString;
        }

        private static IMapper InitializeAndSetupMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); });

            IMapper mapper = new Mapper(mapperConfiguration);
            return mapper;
        }
    }


}