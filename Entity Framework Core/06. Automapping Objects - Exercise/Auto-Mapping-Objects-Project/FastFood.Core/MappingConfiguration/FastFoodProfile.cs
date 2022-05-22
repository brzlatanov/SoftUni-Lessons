﻿using FastFood.Core.ViewModels.Categories;
using FastFood.Core.ViewModels.Employees;
using FastFood.Services.DTO.Category;
using FastFood.Services.DTO.Employee;
using FastFood.Services.DTO.Position;

namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Models;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories
            this.CreateMap<CreateCategoryDTO, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, ListAllCategoriesDTO>()
                .ForMember(x=> x.CategoryName, y=> y.MapFrom(s=> s.Name));

            this.CreateMap<CreateCategoryInputModel, CreateCategoryDTO>();

            this.CreateMap<ListAllCategoriesDTO, CategoryAllViewModel>().ForMember(x=> x.Name, y=> y.MapFrom(s=> s.CategoryName));

            this.CreateMap<Position, EmployeeRegisterPositionsAvailable>()
                .ForMember(x=> x.PositionId, y=> y.MapFrom(s=> s.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));

            this.CreateMap<EmployeeRegisterPositionsAvailable, RegisterEmployeeViewModel>();

            this.CreateMap<RegisterEmployeeInputModel, RegisterEmployeeDTO>();

            this.CreateMap<RegisterEmployeeDTO, Employee>();

            this.CreateMap<ListAllEmployeesDTO, EmployeesAllViewModel>();

            this.CreateMap<Employee, ListAllEmployeesDTO>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));
        }
    }
}
