using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");

            ImportSuppliers(context, inputSuppliers);
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {

            var supplierDtos = JsonConvert.DeserializeObject<SupplierInputDto[]>(inputJson);

            var mapper = InitializeAndSetupMapper();

            var suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);

            return $"Successfully imported {context.SaveChanges()}.";
        }

        private static IMapper InitializeAndSetupMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); });

            IMapper mapper = new Mapper(mapperConfiguration);
            return mapper;
        }
    }

   
}