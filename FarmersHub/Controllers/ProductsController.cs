using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmersHub.Data;
using FarmersHub.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersHub.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Farmer")]
        public IActionResult Add() => View();

        [HttpPost, Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Add(Product product)
        {
            var user = await _userManager.GetUserAsync(User);
            var farmer = _context.Farmers.FirstOrDefault(f => f.Name.Contains("John"));
            if (farmer == null) return NotFound();

            product.FarmerId = farmer.Id;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("MyProducts");
        }

        [Authorize(Roles = "Farmer")]
        public IActionResult MyProducts()
        {
            var products = _context.Products.Include(p => p.Farmer).Where(p => p.Farmer.Name.Contains("John")).ToList();
            return View(products);
        }

        [Authorize(Roles = "Employee")]
        /*public IActionResult Filter(string category, DateTime? from, DateTime? to)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);
            if (from.HasValue)
                query = query.Where(p => p.ProductionDate >= from);
            if (to.HasValue)
                query = query.Where(p => p.ProductionDate <= to);

            return View(query.ToList());
        }*/
        [HttpGet]
        public async Task<IActionResult> Filter(string category, DateTime? from, DateTime? to)
        {
            var products = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.Contains(category));
            }

            if (from.HasValue)
            {
                products = products.Where(p => p.ProductionDate >= from.Value);
            }

            if (to.HasValue)
            {
                products = products.Where(p => p.ProductionDate <= to.Value);
            }

            var filteredProducts = await products.ToListAsync();
            return View(filteredProducts);
        }
    }

}
