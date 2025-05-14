using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FarmersHub.Data;
using FarmersHub.Models;
using System.Threading.Tasks;
using System.Linq;

namespace FarmersHub.Controllers
{
    [Authorize(Roles = "Employee")]
    public class FarmersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FarmersController(ApplicationDbContext context) => _context = context;

        public IActionResult Index() => View(_context.Farmers.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Farmer farmer)
        {
            if (!ModelState.IsValid) return View(farmer);
            _context.Farmers.Add(farmer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }

}
