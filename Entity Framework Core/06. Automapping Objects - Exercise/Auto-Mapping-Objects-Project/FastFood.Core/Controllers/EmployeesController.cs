using System.Collections.Generic;
using System.Linq;
using FastFood.Services.DTO.Employee;
using FastFood.Services.DTO.Position;
using FastFood.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Core.Controllers
{
    using System;
    using AutoMapper;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IPositionService positionService;
        private readonly IMapper mapper;
        private readonly IEmployeeService employeeService;

        public EmployeesController(IMapper mapper, IPositionService positionService, IEmployeeService employeeService)
        {
            this.positionService = positionService;
            this.mapper = mapper;
            this.employeeService = employeeService;
        }

        public IActionResult Register()
        {

            ICollection<EmployeeRegisterPositionsAvailable> positionsDTO = this.positionService.GetPositionsAvailable();

            List<RegisterEmployeeViewModel> regViewModel = this.mapper
                .Map<ICollection<EmployeeRegisterPositionsAvailable>, ICollection<RegisterEmployeeViewModel>>(positionsDTO).ToList();

            return this.View(regViewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Register");
            }

            RegisterEmployeeDTO employeeDto = this.mapper.Map<RegisterEmployeeDTO>(model);

            this.employeeService.Register(employeeDto);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            ICollection<ListAllEmployeesDTO> employeesDtos = this.employeeService.All();

            List<EmployeesAllViewModel> employeesViewModels =
                this.mapper.Map<ICollection<ListAllEmployeesDTO>, ICollection<EmployeesAllViewModel>>(employeesDtos).ToList();

            return this.View(employeesViewModels);
        }
    }
}
