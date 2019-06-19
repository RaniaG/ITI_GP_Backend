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
        public virtual DbSet<Order> Orders { get; set; }


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


            /*Orders table*/
            var orders = modelBuilder.Entity<Order>();
            orders.HasKey(o => o.id);
            orders.HasRequired(o => o.shipmentData);
            orders.HasRequired(o => o.user);
            


        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}