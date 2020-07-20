using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FixMeetWebApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public UserRole UserRole { get; set; }
        public Category Category { get; set; }

        public double Rating { get; set; }



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
            : base("FixMeet", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<RequestModels> RequestModels { get; set; }

        public DbSet<OfferModels> OfferModels { get; set; }

        public DbSet<BookingModels> BookingModels { get; set; }

        public System.Data.Entity.DbSet<FixMeetWebApi.Models.RatingModels> RatingModels { get; set; }

        object placeHolderVariable;
        public System.Data.Entity.DbSet<FixMeetWebApi.Models.NegotiationChatModels> NegotiationChatModels { get; set; }
    }
}