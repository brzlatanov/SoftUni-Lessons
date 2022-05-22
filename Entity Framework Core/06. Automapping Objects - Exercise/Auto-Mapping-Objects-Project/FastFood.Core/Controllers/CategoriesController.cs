using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using FastFood.Models;
using FastFood.Services.DTO.Category;
using FastFood.Services.Interfaces;

namespace FastFood.Core.Controllers
{
    using System;
    using AutoMapper;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }

            CreateCategoryDTO categoryDto = this.mapper.Map<CreateCategoryDTO>(model);

            this.categoryService.Create(categoryDto);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            ICollection<ListAllCategoriesDTO> categoriesDtos = this.categoryService.All();

            List<CategoryAllViewModel> categoryViewModels =
                this.mapper.Map<ICollection<ListAllCategoriesDTO>, ICollection<CategoryAllViewModel>>(categoriesDtos).ToList();

            return this.View("All", categoryViewModels);
        }
    }
}
