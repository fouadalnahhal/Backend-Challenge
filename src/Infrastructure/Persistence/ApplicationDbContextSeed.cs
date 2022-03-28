using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var administratorRole = new IdentityRole("Administrator");

        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
        }

        var employeeRole = new IdentityRole("Employee");

        if (roleManager.Roles.All(r => r.Name != employeeRole.Name))
        {
            await roleManager.CreateAsync(employeeRole);
        }

        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        var Employee1 = new ApplicationUser { UserName = "ُEmployee1@localhost", Email = "Employee1@localhost", Salary = 12000 };
        var Employee2 = new ApplicationUser { UserName = "ُEmployee2@localhost", Email = "Employee2@localhost", Salary = 15000 };
        var Employee3 = new ApplicationUser { UserName = "ُEmployee3@localhost", Email = "Employee3@localhost", Salary = 18000 };
        var Employee4 = new ApplicationUser { UserName = "ُEmployee4@localhost", Email = "Employee4@localhost", Salary = 12000 };
        var Employee5 = new ApplicationUser { UserName = "ُEmployee5@localhost", Email = "Employee5@localhost", Salary = 10000 };


        if (userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await userManager.CreateAsync(administrator, "Administrator1!");
            await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        }

        //if (userManager.Users.All(u => u.UserName != Employee1.UserName))
        //{
        //    await userManager.CreateAsync(Employee1, "P@ssw0rd");
        //    await userManager.AddToRolesAsync(Employee1, new[] { employeeRole.Name });
        //}

        //if (userManager.Users.All(u => u.UserName != Employee2.UserName))
        //{
        //    await userManager.CreateAsync(Employee2, "P@ssw0rd");
        //    await userManager.AddToRolesAsync(Employee2, new[] { employeeRole.Name });
        //}

        //if (userManager.Users.All(u => u.UserName != Employee3.UserName))
        //{
        //    await userManager.CreateAsync(Employee3, "P@ssw0rd");
        //    await userManager.AddToRolesAsync(Employee3, new[] { employeeRole.Name });
        //}

        //if (userManager.Users.All(u => u.UserName != Employee4.UserName))
        //{
        //    await userManager.CreateAsync(Employee4, "P@ssw0rd");
        //    await userManager.AddToRolesAsync(Employee4, new[] { employeeRole.Name });
        //}

        //if (userManager.Users.All(u => u.UserName != Employee5.UserName))
        //{
        //    await userManager.CreateAsync(Employee5, "P@ssw0rd");
        //    await userManager.AddToRolesAsync(Employee5, new[] { employeeRole.Name });
        //}
    }

    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        // Seed, if necessary
        if (!context.TodoLists.Any())
        {
            context.TodoLists.Add(new TodoList
            {
                Title = "Shopping",
                Colour = Colour.Blue,
                Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
            });

            await context.SaveChangesAsync();
        }
    }
}
