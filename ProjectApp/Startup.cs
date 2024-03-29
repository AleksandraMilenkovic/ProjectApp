﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ProjectApp.Models;

[assembly: OwinStartupAttribute(typeof(ProjectApp.Startup))]
namespace ProjectApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("ADMIN"))
            {
                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "ADMIN";
                roleManager.Create(role);
            }

            // creating Creating Manager role     
            if (!roleManager.RoleExists("EMPLOYEE"))
            {
                var role = new IdentityRole();
                role.Name = "EMPLOYEE";
                roleManager.Create(role);
            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("GUEST"))
            {
                var role = new IdentityRole();
                role.Name = "GUEST";
                roleManager.Create(role);
            }

            //Here we create a Admin super user who will maintain the website 
            if (UserManager.FindByName("sqladmin") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "sqladmin";
                user.Email = "";

                string userPWD = "Password1@";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "ADMIN");

                }
            }
        }
    }
}
