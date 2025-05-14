using Microsoft.AspNetCore.Identity;
using FarmersHub.Models;

namespace FarmersHub.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            var roles = new[] { "Farmer", "Employee" };
            foreach (var role in roles)
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));

            if (await userManager.FindByEmailAsync("farmer1@agri.com") == null)
            {
                var farmerUser = new ApplicationUser { UserName = "farmer1@agri.com", Email = "farmer1@agri.com", Role = "Farmer" };
                await userManager.CreateAsync(farmerUser, "Agri123!");
                await userManager.AddToRoleAsync(farmerUser, "Farmer");

                var farmer = new Farmer { Name = "John's Farm", Location = "Limpopo" };
                context.Farmers.Add(farmer);
                await context.SaveChangesAsync();

                context.Products.AddRange(
                    new Product { Name = "Organic Maize", Category = "Grain", ProductionDate = DateTime.Now.AddDays(-30), FarmerId = farmer.Id },
                    new Product { Name = "Free Range Eggs", Category = "Poultry", ProductionDate = DateTime.Now.AddDays(-10), FarmerId = farmer.Id }
                );
            }

            if (await userManager.FindByEmailAsync("employee1@agri.com") == null)
            {
                var employeeUser = new ApplicationUser { UserName = "employee1@agri.com", Email = "employee1@agri.com", Role = "Employee" };
                await userManager.CreateAsync(employeeUser, "Agri123!");
                await userManager.AddToRoleAsync(employeeUser, "Employee");
            }

            await context.SaveChangesAsync();
        }
    }
}
