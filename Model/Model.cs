namespace model
{
    using global::model.Entities;
    using System;
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


            //user shipmentData relation
            users.HasMany(u => u.shipmentDatas)
                .WithRequired(sd => sd.user)
                .HasForeignKey(sd => sd.user_id);

            /*Shipment data table*/
            var shipmentData = modelBuilder.Entity<ShipmentData>();
            shipmentData.HasKey(sd => new { sd.id, sd.user_id });
            shipmentData.Property(sd => sd.fullAddress).IsRequired().HasMaxLength(200);
            shipmentData.Property(sd => sd.contactName).IsRequired().HasMaxLength(100);
            shipmentData.Property(sd => sd.contactEmail).IsRequired().HasMaxLength(50);

            //User Shop Realtion
            modelBuilder.Entity<User>()
                .HasOptional(u => u.Shop)
                .WithRequired(sh => sh.User);



        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}