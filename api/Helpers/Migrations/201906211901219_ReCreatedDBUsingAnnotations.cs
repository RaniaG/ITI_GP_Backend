namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReCreatedDBUsingAnnotations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Variations = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.UserId })
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Discount = c.Double(),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        Terms = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        MinDeliveryTime = c.Int(nullable: false),
                        MaxDeliveryTime = c.Int(nullable: false),
                        Variations = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                        Images = c.String(),
                        PublishTime = c.DateTime(nullable: false),
                        LifeTime = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        ShopID = c.String(maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Shops", t => t.ShopID)
                .Index(t => t.ShopID)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Photo = c.String(),
                        Cover = c.String(),
                        Rating = c.Double(nullable: false),
                        About = c.String(),
                        Policy = c.String(nullable: false),
                        Subscription = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        PostalCode = c.String(),
                        Street = c.String(),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ShopId = c.String(maxLength: 128),
                        Status = c.Int(nullable: false),
                        DeliveryTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Shops", t => t.ShopId)
                .Index(t => t.OrderId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentMethod = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ShipmentDataId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShipmentDatas", t => t.ShipmentDataId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ShipmentDataId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Variations = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ShipmentDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FullAddress = c.String(),
                        PostalCode = c.Int(),
                        ContactPhone = c.String(nullable: false),
                        ContactName = c.String(nullable: false),
                        ContactEmail = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CityId)
                .Index(t => t.CountryId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.ReviewRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Review = c.String(nullable: false),
                        DelieveryServiceReview = c.String(),
                        ShopServiceReview = c.String(),
                        ProductRating = c.Double(nullable: false),
                        ShopRating = c.Double(nullable: false),
                        UserId = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        ShopId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Shops", t => t.ShopId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.ShopVisits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Location = c.String(),
                        ShopId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.ShopId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.ShopDeliveryAddresses",
                c => new
                    {
                        CityId = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        ShopId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CityId, t.CountryID, t.DistrictId, t.ShopId })
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryID)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .ForeignKey("dbo.Shops", t => t.ShopId)
                .Index(t => t.CityId)
                .Index(t => t.CountryID)
                .Index(t => t.DistrictId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.FavouriteProducts",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Product_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.FollowedShops",
                c => new
                    {
                        Shop_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Shop_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Shops", t => t.Shop_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Shop_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Photo", c => c.String());
            AddColumn("dbo.AspNetUsers", "CoverPhoto", c => c.String());
            AddColumn("dbo.AspNetUsers", "Biography", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShopId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopDeliveryAddresses", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.ShopDeliveryAddresses", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.ShopDeliveryAddresses", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.ShopDeliveryAddresses", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Carts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ShopID", "dbo.Shops");
            DropForeignKey("dbo.ShopVisits", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.Shops", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewRatings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewRatings", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.ReviewRatings", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Packages", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.Packages", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ShipmentDataId", "dbo.ShipmentDatas");
            DropForeignKey("dbo.ShipmentDatas", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShipmentDatas", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.ShipmentDatas", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.ShipmentDatas", "CityId", "dbo.Cities");
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.FollowedShops", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FollowedShops", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.Shops", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Shops", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Shops", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.FavouriteProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.FavouriteProducts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.FollowedShops", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FollowedShops", new[] { "Shop_Id" });
            DropIndex("dbo.FavouriteProducts", new[] { "Product_Id" });
            DropIndex("dbo.FavouriteProducts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "ShopId" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "DistrictId" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "CountryID" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "CityId" });
            DropIndex("dbo.ShopVisits", new[] { "ShopId" });
            DropIndex("dbo.ReviewRatings", new[] { "ShopId" });
            DropIndex("dbo.ReviewRatings", new[] { "ProductId" });
            DropIndex("dbo.ReviewRatings", new[] { "UserId" });
            DropIndex("dbo.ShipmentDatas", new[] { "DistrictId" });
            DropIndex("dbo.ShipmentDatas", new[] { "CountryId" });
            DropIndex("dbo.ShipmentDatas", new[] { "CityId" });
            DropIndex("dbo.ShipmentDatas", new[] { "UserId" });
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "ShipmentDataId" });
            DropIndex("dbo.Packages", new[] { "ShopId" });
            DropIndex("dbo.Packages", new[] { "OrderId" });
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Shops", new[] { "DistrictId" });
            DropIndex("dbo.Shops", new[] { "CityId" });
            DropIndex("dbo.Shops", new[] { "CountryId" });
            DropIndex("dbo.Shops", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ShopID" });
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropColumn("dbo.AspNetUsers", "ShopId");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Biography");
            DropColumn("dbo.AspNetUsers", "CoverPhoto");
            DropColumn("dbo.AspNetUsers", "Photo");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.FollowedShops");
            DropTable("dbo.FavouriteProducts");
            DropTable("dbo.ShopDeliveryAddresses");
            DropTable("dbo.ShopVisits");
            DropTable("dbo.ReviewRatings");
            DropTable("dbo.ShipmentDatas");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.Packages");
            DropTable("dbo.Districts");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Shops");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
        }
    }
}
