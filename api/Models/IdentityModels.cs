using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;


using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace api.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Photo { get; set; }
        public string CoverPhoto { get; set; }

        public string Biography { get; set; }
        public Gender Gender { get; set; }

        //public virtual Shop Shop { get; set; }

        public List<ShipmentData> ShipmentDatas { get; set; }
        public List<Cart> Cart { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> FavouriteProducts { get; set; }

        public List<Shop> FollowedShops { get; set; }
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

            /*Users table*/
            var users = modelBuilder.Entity<ApplicationUser>();
            users.ToTable("User");

            ///*Products table*/
            var products = modelBuilder.Entity<Product>();
            products.HasKey(p => p.Id);
            products.Property(p => p.Name)
                .IsRequired().HasMaxLength(100);
            products.Property(p => p.Description).IsOptional().HasColumnType("nvarchar(max)");
            products.Property(p => p.Terms).IsOptional().HasColumnType("nvarchar(max)");
            products.Property(p => p.Variations).IsOptional().HasColumnType("nvarchar(max)");
            products.Property(p => p.Images).IsOptional().HasColumnType("nvarchar(max)");
            products.Property(p => p.PublishTime).IsOptional();
            products.Property(p => p.LifeTime).IsOptional();


            /*Shops table*/
            var shops = modelBuilder.Entity<Shop>();
            shops.HasKey(sh => sh.UserId).Property(sh=>sh.UserId).HasMaxLength(128);
            //shops.HasIndex(sh => sh.Name).IsUnique();
            shops.Property(sh => sh.Name).IsRequired().HasMaxLength(200);
            shops.Property(sh => sh.Photo).IsOptional().HasColumnType("nvarchar(max)");
            shops.Property(sh => sh.Cover).IsOptional().HasColumnType("nvarchar(max)");
            shops.Property(sh => sh.Policy).IsRequired().HasColumnType("nvarchar(max)");

            /*orders table*/
            var orders = modelBuilder.Entity<Order>();
            orders.HasKey(o => o.Id);

            /*Category table*/
            var category = modelBuilder.Entity<Category>();
            category.HasKey(cat => cat.Id);
            category.Property(cat => cat.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            /*cities table*/
            var cities = modelBuilder.Entity<City>();
            cities.HasKey(c => c.Id)
            .Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(200);

            /*country table*/
            var country = modelBuilder.Entity<Country>();
            country.HasKey(c => c.Id)
                .Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(200);

            /*district table*/
            var districts = modelBuilder.Entity<District>();
            districts.HasKey(c => c.Id)
                .Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(200);

            /*Reviews tables*/
            var reviews = modelBuilder.Entity<ReviewRating>();
            reviews.HasKey(r => r.Id);
            reviews.Property(r => r.Date)
                .IsRequired();
            reviews.Property(r => r.Review)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
            reviews.Property(r => r.ShopServiceReview)
                .HasColumnType("nvarchar(max)");
            reviews.Property(r => r.DelieveryServiceReview)
                .HasColumnType("nvarchar(max)");

            ///*Change names of all tables*/
            products.ToTable("Product");
            shops.ToTable("Shop");
            orders.ToTable("Order");
            category.ToTable("Category");
            cities.ToTable("City");
            country.ToTable("Country");
            districts.ToTable("District");
            reviews.ToTable("ReviewRating");


            /*Cart Table*/
            var carts = modelBuilder.Entity<Cart>();
            carts.ToTable("CartProduct");
            carts.Property(c => c.User_Id).HasMaxLength(128);
            carts.HasKey(c => new { c.Product_Id, c.User_Id });
            carts.HasRequired(c => c.Product);
            carts.HasRequired(c => c.User);

            carts.Property(c => c.Variations)
                .HasColumnType("nvarchar(max)").IsRequired();

            /*Visits table*/
            var visits = modelBuilder.Entity<ShopVisit>();
            visits.HasKey(v=>v.Id).HasRequired(v => v.Shop);

            /*Shipment data table*/
            var shipmentData = modelBuilder.Entity<ShipmentData>();
            shipmentData.HasKey(sd => new { sd.Id, sd.UserId });
            shipmentData.Property(sd => sd.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            shipmentData.Property(sd => sd.FullAddress).IsRequired().HasMaxLength(200);
            shipmentData.Property(sd => sd.ContactName).IsRequired().HasMaxLength(100);
            shipmentData.Property(sd => sd.ContactPhone).IsRequired().HasMaxLength(20);
            shipmentData.Property(sd => sd.ContactEmail).IsRequired().HasMaxLength(50);
            shipmentData.Property(sd => sd.UserId).HasMaxLength(128);
            shipmentData.HasRequired(sd => sd.User);

            //order product table
            var orderproducts = modelBuilder.Entity<OrderProduct>();
            orderproducts.HasRequired(op => op.Order);
            orderproducts.HasRequired(op => op.Product);
            orderproducts.HasKey(op => new { op.OrderId, op.ProductId });
            orderproducts.Property(op => op.Variations).HasColumnType("nvarchar(max)");

            //package table

            var package = modelBuilder.Entity<Package>();
            package.Property(p => p.ShopId).HasMaxLength(128);
            package.HasRequired(p => p.Order);
            package.HasRequired(p => p.Shop);
            package.HasKey(p => new {p.Id,p.OrderId,p.ShopId });

            /*Shop Addresses Table*/
            var shopaddresses = modelBuilder.Entity<ShopDeliveryAddresses>();
            shopaddresses.Property(sa => sa.ShopId).HasMaxLength(128);
            shopaddresses.HasKey(sa => new { sa.CityId, sa.CountryID, sa.DistrictId, sa.ShopId });

            /***************Relations*******************/

            //Country City Relation
            country
                .HasMany(c => c.Cities)
                .WithRequired(c => c.Country)
                .HasForeignKey(c => c.CountryId)
                .WillCascadeOnDelete(false);

            //City District Relation
            cities
                .HasMany(c => c.Districts)
                .WithRequired(c => c.City)
                .HasForeignKey(c => c.CityId)
                .WillCascadeOnDelete(false);

            //product relations
            products.HasRequired(p => p.Shop);
            products.HasRequired(p => p.Category);
            products.Property(p => p.ShopId).HasMaxLength(128);

            //user shop relation
            shops.HasRequired(sh => sh.User);

            //orders relation
            orders.HasRequired(o => o.User);
            orders.HasRequired(o => o.ShipmentData);
            orders.Property(o => o.UserId).HasMaxLength(128);


            //review rating relations
            reviews.Property(o => o.UserId).IsRequired().HasMaxLength(128);
            reviews.Property(o => o.ShopId).IsRequired().HasMaxLength(128);

            reviews.HasRequired(r => r.Shop);
            reviews.HasRequired(r => r.Product);
            reviews.HasRequired(r => r.Shop);

            //shop country city district relations
            shops.HasRequired(sh => sh.City);
            shops.HasRequired(sh => sh.Country);
            shops.HasRequired(sh => sh.District);


            //follow shop relation
            shops.HasMany(s => s.FollowedBy).WithMany(u => u.FollowedShops);





            /***************************************************************/
            
        }
    }
}