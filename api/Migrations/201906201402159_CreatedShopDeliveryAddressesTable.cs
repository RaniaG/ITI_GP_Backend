namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedShopDeliveryAddressesTable : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Country", t => t.CountryID)
                .ForeignKey("dbo.District", t => t.DistrictId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .Index(t => t.CityId)
                .Index(t => t.CountryID)
                .Index(t => t.DistrictId)
                .Index(t => t.ShopId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopDeliveryAddresses", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.ShopDeliveryAddresses", "DistrictId", "dbo.District");
            DropForeignKey("dbo.ShopDeliveryAddresses", "CountryID", "dbo.Country");
            DropForeignKey("dbo.ShopDeliveryAddresses", "CityId", "dbo.City");
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "ShopId" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "DistrictId" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "CountryID" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "CityId" });
            DropTable("dbo.ShopDeliveryAddresses");
        }
    }
}
