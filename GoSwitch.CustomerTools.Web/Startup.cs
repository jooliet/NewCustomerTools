using System;
using GoSwitch.CustomerTools.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoSwitch.CustomerTools.Web.Startup))]
namespace GoSwitch.CustomerTools.Web
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
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    var account = new UserAccount();
                    account.FirstName = "Super";
                    account.LastName = "Admin";
                    account.Email = "anna@vevos.digital";
                    account.IsActive = true;
                    account.UserName = account.Email;
                    account.PhoneNumber = "04123456789";
                    account.CallCenterID = 1;
                    account.SupervisorID = string.Empty;


                    var applicationUser = new ApplicationUser { UserName = account.FirstName, Email = account.Email, UserAccount = account, PhoneNumber = account.PhoneNumber };

                    var chkUser = userManager.Create(applicationUser, "P@ssw0rd1");

                }

                if (!roleManager.RoleExists("Supervisor"))
                {
                    var role = new IdentityRole();
                    role.Name = "Supervisor";
                    roleManager.Create(role);
                }


                if (!roleManager.RoleExists("Data Analyst"))
                {
                    var role = new IdentityRole();
                    role.Name = "Data Analyst";
                    roleManager.Create(role);
                }

                if (!roleManager.RoleExists("Supervisor"))
                {
                    var role = new IdentityRole();
                    role.Name = "Supervisor";
                    roleManager.Create(role);
                }

                if (!roleManager.RoleExists("Agent"))
                {
                    var role = new IdentityRole();
                    role.Name = "Agent";
                    roleManager.Create(role);
                }




            }
        }
    }
}
