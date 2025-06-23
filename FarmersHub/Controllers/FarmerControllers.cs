using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FarmersHub.Data;
using FarmersHub.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FarmersHub.Controllers
{
    [Authorize(Roles = "Employee")]
    public class FarmersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FarmersController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Farmers.ToListAsync());

        [Authorize(Roles = "Employee")]
        public IActionResult Create() => View();

        [HttpPost, Authorize(Roles = "Employee")]
        public async Task<IActionResult> Create(Farmer farmer)
        {
            
            _context.Farmers.Add(farmer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }

}
