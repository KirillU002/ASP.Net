using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShop.Db;
namespace ASP.Net
{
    public class IdentityInitializer
    {
        public IdentityInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) 
        {
            var adminEmail = "admin@bk.ru";
            var password = "password";

            if (roleManager.FindByNameAsync(ConstantsDb.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(ConstantsDb.AdminRoleName)).Wait();
            }

            if (roleManager.FindByNameAsync(ConstantsDb.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(ConstantsDb.UserRoleName)).Wait();
            }

            if (userManager.FindByNameAsync(adminEmail).Result==null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail };
                var result = userManager.CreateAsync(admin, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, ConstantsDb.AdminRoleName).Wait();
                }
            }
        }
    }
}
