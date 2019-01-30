using Hotels.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.EF
{
    public static class UserSeeder
    {
        public async static Task Seed(UserManager<AppUser> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            var admin = await userMgr.FindByNameAsync("admin");

            if (admin == null)
            {
                if (!(await roleMgr.RoleExistsAsync("admin")))
                {
                    var role = new IdentityRole("admin");
                    await roleMgr.CreateAsync(role);
                }

                admin = new AppUser()
                {
                    FirstName = "admin first name",
                    LastName = "admin last name",
                    UserName = "admin123"
                    
                };

                var userResult = await userMgr.CreateAsync(admin, "qwe123");
                var roleResult = await userMgr.AddToRoleAsync(admin, "admin");
            }

            var user1 = await userMgr.FindByNameAsync("user1");
            var user2 = await userMgr.FindByNameAsync("user2");

            if (user1 == null & user2 == null)
            {
                if (!(await roleMgr.RoleExistsAsync("user")))
                {
                    var role = new IdentityRole("user");
                    await roleMgr.CreateAsync(role);
                }

                user1 = new AppUser()
                {
                    FirstName = "user1 first name",
                    LastName = "user1 last name",
                    UserName = "user1",
                };

                user2 = new AppUser()
                {
                    FirstName = "user2 first name",
                    LastName = "user2 last name",
                    UserName = "user2",

                };

                var userResult1 = await userMgr.CreateAsync(user1, "pw1234");
                var userResult2 = await userMgr.CreateAsync(user2, "pw1234");
                await userMgr.AddToRoleAsync(user1, "user");
                await userMgr.AddToRoleAsync(user2, "user");

            }
        }
    }
}
