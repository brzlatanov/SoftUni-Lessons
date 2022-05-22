﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO.Input;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierInputDto, Supplier>();
            CreateMap<PartInputDto, Part>();
            CreateMap<PartCarInputDto, PartCar>();
            CreateMap<PartInputIdDto, PartCar>();
            CreateMap<CarInputDto, Car>();
        }
    }
}
