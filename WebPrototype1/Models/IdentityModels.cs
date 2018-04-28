using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebPrototype1.Models
{
    // Sie können Profildaten für den Benutzer hinzufügen, indem Sie der ApplicationUser-Klasse weitere Eigenschaften hinzufügen. Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Beachten Sie, dass der "authenticationType" mit dem in "CookieAuthenticationOptions.AuthenticationType" definierten Typ übereinstimmen muss.
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Benutzerdefinierte Benutzeransprüche hier hinzufügen
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

        public System.Data.Entity.DbSet<WebPrototype1.Models.Contract> Contracts { get; set; }

        public System.Data.Entity.DbSet<WebPrototype1.Models.Provider> Providers { get; set; }

        public System.Data.Entity.DbSet<WebPrototype1.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<WebPrototype1.Models.MobilePhone> MobilePhones { get; set; }

        public System.Data.Entity.DbSet<WebPrototype1.Models.MobilePhoneProvider> MobilePhoneProviders { get; set; }

        public System.Data.Entity.DbSet<WebPrototype1.Models.Mobilfunk> Mobilfunks { get; set; }

        public System.Data.Entity.DbSet<WebPrototype1.Models.Offering> Offerings { get; set; }

        public System.Data.Entity.DbSet<WebPrototype1.Models.Pricing> Pricings { get; set; }

        public System.Data.Entity.DbSet<WebPrototype1.Models.Rating> Ratings { get; set; }
    }
}