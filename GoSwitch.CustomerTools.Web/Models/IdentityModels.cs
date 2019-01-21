using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GoSwitch.CustomerTools.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class PasswordHistory
    {
        public DateTime CreatedDate { get; set; }

        [Key, Column(Order = 1)]
        public string PasswordHash { get; set; }

        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public PasswordHistory()
        {
            CreatedDate = DateTime.Now;

        }



    }

    public class UserAccount
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CallCenterID { get; set; }
        public string SupervisorID { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
        //public int AccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public int CallCenterID { get; set; }
        //public string SupervisorID { get; set; }

        //public bool IsActive { get; set; }


        public virtual List<PasswordHistory> PasswordHistory { get; set; }
        public ApplicationUser() : base()
        {
            PasswordHistory = new List<PasswordHistory>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<UserAccount> Accounts { get; set; }

        

    }

    

}