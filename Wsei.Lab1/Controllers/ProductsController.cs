using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wsei.Lab1.Controllers.Entities;
using Wsei.Lab1.Database;
using Wsei.Lab1.Models;

namespace Wsei.Lab1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductsController (AppDbContext dbContext )
        {
        _dbContext = dbContext ;
        }

        [HttpGet]
        public async Task<IActionResult> List(string name)
        {
            IQueryable<ProductEntity> productsQuery = _dbContext.Products;

            if (!string.IsNullOrEmpty(name))
            {
                productsQuery = productsQuery.Where(x => x.Name.Contains(name));
            }
            var products = await productsQuery.ToListAsync();

            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult > Add(ProductModel product )
        {
            var entity = new ProductEntity
            {
                Name = product .Name,
                Description = product .Description,
                IsVisible = product .IsVisible,
            };

            await _dbContext .AddAsync (entity);
            await _dbContext .SaveChangesAsync ();

            return View();
        }
    }
}