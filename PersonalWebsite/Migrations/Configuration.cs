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
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }
   
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            ApplicationUser user;
            
            //Beginning of Adding Admin
            if (!context.Users.Any(r => r.Email == "joncarlee@gmail.com"))
            {
                user = new ApplicationUser
                {
                    UserName = "joncarlee@gmail.com",
                    Email = "joncarlee@gmail.com",
                    FirstName = "Jon",
                    LastName = "Carlee",
                    DisplayName = "Jon Carlee"
                };
                userManager.Create(user, "This is my page");
            }
            else
            {
                user = context.Users.Single(u => u.Email == "joncarlee@gmail.com");
            }
            if (!userManager.IsInRole(user.Id, "Admin"))
            {
                userManager.AddToRole(user.Id, "Admin");
            }
            //End of Adding Admin

            //Beginning of Adding Moderator
            if (!context.Users.Any(r => r.Email == "lreaves@coderfoundry.com"))
            {
                user = new ApplicationUser
                {
                    UserName = "lreaves@coderfoundry.com",
                    Email = "lreaves@coderfoundry.com",
                };
                userManager.Create(user, "Password-1");
            }
            else
            {
                user = context.Users.Single(u => u.Email == "lreaves@coderfoundry.com");
            }
            if (!userManager.IsInRole(user.Id, "Moderator"))
            {
                userManager.AddToRole(user.Id, "Moderator");
            }
            //End of Adding Moderator

            //Beginning of Adding Moderator
            if (!context.Users.Any(r => r.Email == "bdavis@coderfoundry.com"))
            {
                user = new ApplicationUser
                {
                    UserName = "bdavis@coderfoundry.com",
                    Email = "bdavis@coderfoundry.com",
                };
                userManager.Create(user, "Password-1");
            }
            else
            {
                user = context.Users.Single(u => u.Email == "bdavis@coderfoundry.com");
            }
            if (!userManager.IsInRole(user.Id, "Moderator"))
            {
                userManager.AddToRole(user.Id, "Moderator");
            }
            //End of Adding Moderator

            //Beginning of Adding Moderator
            if (!context.Users.Any(r => r.Email == "ajensen@coderfoundry.com"))
            {
                user = new ApplicationUser
                {
                    UserName = "ajensen@coderfoundry.com",
                    Email = "ajensen@coderfoundry.com",
                };
                userManager.Create(user, "Password-1");
            }
            else
            {
                user = context.Users.Single(u => u.Email == "ajensen@coderfoundry.com");
            }
            if (!userManager.IsInRole(user.Id, "Moderator"))
            {
                userManager.AddToRole(user.Id, "Moderator");
            }
            //End of Adding Moderator

            //Beginning of Adding Moderator
            if (!context.Users.Any(r => r.Email == "tjones@coderfoundry.com"))
            {
                user = new ApplicationUser
                {
                    UserName = "tjones@coderfoundry.com",
                    Email = "tjones@coderfoundry.com",
                };
                userManager.Create(user, "Password-1");
            }
            else
            {
                user = context.Users.Single(u => u.Email == "tjones@coderfoundry.com");
            }
            if (!userManager.IsInRole(user.Id, "Moderator"))
            {
                userManager.AddToRole(user.Id, "Moderator");
            }
            //End of Adding Moderator

            //Beginning of Adding Moderator
            if (!context.Users.Any(r => r.Email == "tparrish@coderfoundry.com"))
            {
                user = new ApplicationUser
                {
                    UserName = "tparrish@coderfoundry.com",
                    Email = "tparrish@coderfoundry.com",
                };
                userManager.Create(user, "Password-1");
            }
            else
            {
                user = context.Users.Single(u => u.Email == "tparrish@coderfoundry.com");
            }
            if (!userManager.IsInRole(user.Id, "Moderator"))
            {
                userManager.AddToRole(user.Id, "Moderator");
            }
            //End of Adding Moderator

            }
        }
    }