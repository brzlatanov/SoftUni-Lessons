using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dto.Input;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputSuppliers = File.ReadAllText("Datasets/suppliers.xml");
            string inputParts = File.ReadAllText("Datasets/parts.xml");
            string inputCars = File.ReadAllText("Datasets/cars.xml");
            ImportSuppliers(context, inputSuppliers);
            ImportParts(context, inputParts);
            ImportCars(context, inputCars);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierInputDto[]), new XmlRootAttribute("Suppliers"));

            SupplierInputDto[] supplierInputDtos;

            using (var reader = new StringReader(inputXml))
            {
                supplierInputDtos = (SupplierInputDto[])serializer.Deserialize(reader);
            }

            var mapper = InitializeMapperWithCarDealerProfile();

            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierInputDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartInputDto[]), new XmlRootAttribute("Parts"));

            PartInputDto[] partInputDtos;

            using (var reader = new StringReader(inputXml))
            {
                partInputDtos = (PartInputDto[])serializer.Deserialize(reader);
            }

            var mapper = InitializeMapperWithCarDealerProfile();

            Part[] parts = mapper.Map<Part[]>(partInputDtos.Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId)));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml) // create a part Id dto collection
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CarInputDto[]), new XmlRootAttribute("Cars"));

            CarInputDto[] carInputDtos;

            using (var reader = new StringReader(inputXml))
            {
                carInputDtos = (CarInputDto[])serializer.Deserialize(reader);
            }

            ICollection<Car> cars = new HashSet<Car>();

            foreach (var carDto in carInputDtos)
            {
                Car c = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                ICollection<PartCar> currentCarParts = new HashSet<PartCar>();

                foreach (var partId in carDto.Parts.Select(p=> p.Id).Distinct())
                {
                    Part part = context.Parts.Find(partId);

                    if (part == null)
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar
                    {
                        Car = c,
                        Part = part
                    };

                    currentCarParts.Add(partCar);

                    c.PartCars = currentCarParts;

                }

                cars.Add(c);
            }
            
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        private static IMapper InitializeMapperWithCarDealerProfile()
        {
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); });

            Mapper mapper = new Mapper(configuration);

            return mapper;
        }
    }
}