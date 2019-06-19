namespace model
{
    using global::model.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class Model : DbContext
    {
        // Your context has been configured to use a 'Model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Model.Model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model' 
        // connection string in the application configuration file.
        public Model()
            : base("name=Model")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShipmentData> ShipmentDatas { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderProduct> OrderProducts { get; set; }

        public virtual DbSet<Package> Packages { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            /*Products table*/
            var products=modelBuilder.Entity<Product>();
            products.HasKey(p => p.id);
            products.Property(p => p.name)
                .IsRequired().HasMaxLength(100);
            products.Property(p => p.description).IsOptional().HasColumnType("nvarchar(max)");
            products.Property(p => p.terms).IsOptional().HasColumnType("nvarchar(max)");
            products.Property(p => p.variations).IsOptional().HasColumnType("nvarchar(max)");
            products.Property(p => p.images).IsOptional().HasColumnType("nvarchar(max)");
            products.Property(p => p.publishTime).IsOptional();
            products.Property(p => p.lifeTime).IsOptional();

            /*user table*/
            var users = modelBuilder.Entity<User>();
            users.HasKey(u => u.id);
            users.HasIndex(u => u.UserName).IsUnique();
            users.Property(u => u.UserName).IsRequired().HasMaxLength(100);
            users.HasIndex(u => u.Email).IsUnique();
            users.Property(u => u.Email).IsRequired().HasMaxLength(200);
            users.Property(u => u.Password).IsRequired().HasMaxLength(100);
            users.Property(u => u.Fname).HasMaxLength(100);
            users.Property(u => u.Lname).HasMaxLength(100);
            users.Property(u => u.Photo).IsRequired().HasColumnType("nvarchar(max)");
            users.Property(u => u.CoverPhoto).IsRequired().HasColumnType("nvarchar(max)");

            /*Shop table*/
            var shops = modelBuilder.Entity<Shop>();
            shops.HasKey(sh => sh.Id);
            shops.HasIndex(sh => sh.Name).IsUnique();
            shops.Property(sh => sh.Name).IsRequired().HasMaxLength(200);
            shops.Property(sh => sh.Photo).IsRequired().HasColumnType("nvarchar(max)");
            shops.Property(sh => sh.Cover).IsOptional().HasColumnType("nvarchar(max)");
            shops.Property(sh => sh.Policy).IsRequired().HasColumnType("nvarchar(max)");

            /*Country Table*/
            modelBuilder.Entity<Country>()
                .ToTable("Country")
                .HasKey(c => c.Id)
                .Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(200);

            /*City Table*/
            modelBuilder.Entity<City>()
                .ToTable("City")
                .HasKey(c => c.Id)
                .Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(200);

            /*District Table*/
            modelBuilder.Entity<District>()
                .ToTable("District")
                .HasKey(c => c.Id)
                .Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(200);

            //user shipmentData relation
            users.HasMany(u => u.shipmentDatas)
                .WithRequired(sd => sd.user)
                .HasForeignKey(sd => sd.user_id);

            /*Shipment data table*/
            var shipmentData = modelBuilder.Entity<ShipmentData>();
            shipmentData.HasKey(sd => new { sd.id, sd.user_id });
            shipmentData.Property(sd => sd.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            shipmentData.Property(sd => sd.fullAddress).IsRequired().HasMaxLength(200);
            shipmentData.Property(sd => sd.contactName).IsRequired().HasMaxLength(100);
            shipmentData.Property(sd => sd.contactEmail).IsRequired().HasMaxLength(50);

            //User Shop Relation
            modelBuilder.Entity<User>()
                .HasOptional(u => u.Shop)
                .WithRequired(sh => sh.User);

            //Country City Relation
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Cities)
                .WithRequired(c => c.Country)
                .HasForeignKey(c => c.CountryId)
                .WillCascadeOnDelete(false);


            /*Orders table*/
            var orders = modelBuilder.Entity<Order>();
            orders.HasKey(o => o.id);
            orders.HasRequired(o => o.shipmentData);
            orders.HasRequired(o => o.user);



            //City District Relation
            modelBuilder.Entity<City>()
                .HasMany(c => c.Districts)
                .WithRequired(c => c.City)
                .HasForeignKey(c => c.CityId)
                .WillCascadeOnDelete(false);

           
            /*OrderProducts table*/
            var orderProducts = modelBuilder.Entity<OrderProduct>();
            orderProducts.HasRequired(op => op.order);
            orderProducts.HasRequired(op => op.product);
            orderProducts.HasKey(op => new { op.order_id, op.product_id })
                .Property(op => op.variations).HasMaxLength(200);

            /*Package table*/
            var packages = modelBuilder.Entity<Package>();
            packages.HasRequired(p => p.shop);
            packages.HasRequired(p => p.order);
            packages.HasKey(p => new { p.order_id, p.shop_id, p.id });


            

        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}