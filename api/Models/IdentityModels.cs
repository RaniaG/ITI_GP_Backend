using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;


using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Photo { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string CoverPhoto { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Biography { get; set; }
        public Gender Gender { get; set; }

        //public virtual Shop Shop { get; set; }

        public List<ShipmentData> ShipmentDatas { get; set; }
        public List<Cart> Cart { get; set; }

        public List<Product> FavouriteProducts { get; set; }

        public List<Shop> FollowedShops { get; set; }

        public List<Order> Orders { get; set; }

        
        public Shop Shop { get; set; }
        public List<ReviewRating> ReviewedProducts { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
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

        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<ReviewRating> ReviewRatings { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<ShopVisit> ShopVisits { get; set; }

        public DbSet<ShipmentData> ShipmentDatas { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Package> Packages { get; set; }

        public DbSet<ShopDeliveryAddresses> ShopDeliveryAddresses { get; set; }




        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}