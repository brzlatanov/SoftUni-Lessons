using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetStore.Services.Interfaces;
using PetStore.Services.Models.Product;

namespace PetStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductService productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            this.mapper = mapper;
            this.productService = productService;
        }
        public IActionResult All(string order = "ascending")
        {
            ICollection<ListAllProductsServiceModel> allProducts = productService.GetAllProducts(order);
            return View(allProducts);
        }
        [HttpPost]
        public IActionResult All(string searchQuery, string order = "ascending")
        {
            ICollection<ListAllProductsServiceModel> allProducts = productService.GetAllProductsBySearch(searchQuery);
            return View(allProducts);
        }
    }
}
