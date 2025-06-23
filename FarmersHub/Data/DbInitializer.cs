using Microsoft.AspNetCore.Identity;
using FarmersHub.Models;

namespace FarmersHub.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            if (!await roleManager.RoleExistsAsync("Farmer"))
                await roleManager.CreateAsync(new IdentityRole("Farmer"));

            if (!await roleManager.RoleExistsAsync("Employee"))
                await roleManager.CreateAsync(new IdentityRole("Employee"));

            if (!userManager.Users.Any())
            {
                var farmerUser = new ApplicationUser { UserName = "farmer@example.com", Email = "farmer@example.com" };
                await userManager.CreateAsync(farmerUser, "Password123!");
                await userManager.AddToRoleAsync(farmerUser, "Farmer");

                var employeeUser = new ApplicationUser { UserName = "employee@example.com", Email = "employee@example.com" };
                await userManager.CreateAsync(employeeUser, "Password123!");
                await userManager.AddToRoleAsync(employeeUser, "Employee");
            }

            if (!context.Farmers.Any())
            {
                var f1 = new Farmer { Name = "John Doe", Location = "Limpopo", Email = "john@example.com" };
                var f2 = new Farmer { Name = "Jane Smith", Location = "Mpumalanga", Email = "jane@example.com" };
                context.Farmers.AddRange(f1, f2);
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Products.Add(new Product { Name = "Maize", Category = "Grain", ProductionDate = DateTime.Now.AddDays(-10), FarmerId = 1 });
                context.Products.Add(new Product { Name = "Tomato", Category = "Vegetable", ProductionDate = DateTime.Now.AddDays(-5), FarmerId = 2 });
                context.SaveChanges();
            }
        }
    }
}
