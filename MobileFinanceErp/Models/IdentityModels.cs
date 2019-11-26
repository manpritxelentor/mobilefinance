using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MobileFinanceErp.Models.Configuration;

namespace MobileFinanceErp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public int TenantId { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
#if DEBUG
            Database.Log = s => Trace.WriteLine(s);
#endif
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var configurations = typeof(TenantModelMap).Assembly.GetTypes().Where(w => w.BaseType != null && w.BaseType.IsGenericType
                && w.BaseType.Name.Contains("EntityTypeConfiguration")).ToArray()
                .ToArray();

            foreach (var type in configurations)
            {
                dynamic instance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(instance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}