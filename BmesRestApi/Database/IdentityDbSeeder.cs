using System;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Models.Shared;
using Microsoft.AspNetCore.Identity;

namespace BmesRestApi.Database
{
    public class IdentityDbSeeder
    {
        public static void Seed(BmesIdentityDbContext dbContext,
                              RoleManager<IdentityRole> roleManager,
                              UserManager<User> userManager)
        {
            // Create default Users (if there are none)
            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager)
                    .GetAwaiter()
                    .GetResult();
            }

        }

        private static async Task CreateUsers(
            BmesIdentityDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {


            //Create Roles (if they doesn't exist yet)
            if (!await roleManager.RoleExistsAsync(UserRole.Administrator.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.Administrator.ToString()));
            }
            if (!await roleManager.RoleExistsAsync(UserRole.RegisteredUser.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.RegisteredUser.ToString()));
            }

            // Create the "Admin" User account
            var userAdmin = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = "Chinedu Ogbu",
                UserName = "admin@yahoo.com",
                Email = "admin@yahoo.com"
            };
            // Insert "Admin" into the Database and assign the "Administrator" and "Registered" roles to him.
            if (await userManager.FindByNameAsync(userAdmin.UserName) == null)
            {
                await userManager.CreateAsync(userAdmin, "MyGodIsGood2*");
                await userManager.AddToRoleAsync(userAdmin, UserRole.Administrator.ToString());
                await userManager.AddToRoleAsync(userAdmin, UserRole.RegisteredUser.ToString());
                // Remove Lockout and E-Mail confirmation.
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = false;
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
