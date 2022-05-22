using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Employee;
using FastFood.Services.Interfaces;

namespace FastFood.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;
        
        

        public EmployeeService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void Register(RegisterEmployeeDTO dto)
        {
            Employee employee = this.mapper.Map<Employee>(dto);

            this.dbContext.Employees.Add(employee);
            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllEmployeesDTO> All()
            => dbContext.Employees.ProjectTo<ListAllEmployeesDTO>(this.mapper.ConfigurationProvider).ToList();
    }
}