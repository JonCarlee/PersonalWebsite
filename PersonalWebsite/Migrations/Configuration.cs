namespace PersonalWebsite.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PersonalWebsite.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonalWebsite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PersonalWebsite.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            ApplicationUser user;

            if (!context.Users.Any(r => r.Email == "admin@coderfoundry.com"))
            {
                user = new ApplicationUser
                {
                    UserName = "admin@coderfoundry.com",
                    Email = "admin@coderfoundry.com",
                    FirstName = "Jon",
                    LastName = "Carlee",
                    DisplayName = "Jon Carlee"
                };
                userManager.Create(new ApplicationUser { }, "Abc123");
            }
            else
            {
                user = context.Users.Single(u => u.Email == "admin@coderfoundry.com");
            }
            if (!userManager.IsInRole(user.Id, "Admin"))
            {
                userManager.AddToRole(user.Id, "Admin");
            }

            }
        }
    }