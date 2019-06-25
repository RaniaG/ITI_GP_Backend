namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedShopDeliveryAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShopDeliveryAddresses", "CityId", "dbo.Cities");
            DropForeignKey("dbo.ShopDeliveryAddresses", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.ShopDeliveryAddresses", "ShopId", "dbo.Shops");
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "CityId" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "CountryID" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "DistrictId" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "ShopId" });
            DropPrimaryKey("dbo.ShopDeliveryAddresses");
            AddColumn("dbo.ShopDeliveryAddresses", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ShopDeliveryAddresses", "CityId", c => c.Int());
            AlterColumn("dbo.ShopDeliveryAddresses", "DistrictId", c => c.Int());
            AlterColumn("dbo.ShopDeliveryAddresses", "ShopId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.ShopDeliveryAddresses", "Id");
            CreateIndex("dbo.ShopDeliveryAddresses", "CityId");
            CreateIndex("dbo.ShopDeliveryAddresses", "CountryID");
            CreateIndex("dbo.ShopDeliveryAddresses", "DistrictId");
            CreateIndex("dbo.ShopDeliveryAddresses", "ShopId");
            AddForeignKey("dbo.ShopDeliveryAddresses", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.ShopDeliveryAddresses", "DistrictId", "dbo.Districts", "Id");
            AddForeignKey("dbo.ShopDeliveryAddresses", "ShopId", "dbo.Shops", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopDeliveryAddresses", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.ShopDeliveryAddresses", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.ShopDeliveryAddresses", "CityId", "dbo.Cities");
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "ShopId" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "DistrictId" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "CountryID" });
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "CityId" });
            DropPrimaryKey("dbo.ShopDeliveryAddresses");
            AlterColumn("dbo.ShopDeliveryAddresses", "ShopId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ShopDeliveryAddresses", "DistrictId", c => c.Int(nullable: false));
            AlterColumn("dbo.ShopDeliveryAddresses", "CityId", c => c.Int(nullable: false));
            DropColumn("dbo.ShopDeliveryAddresses", "Id");
            AddPrimaryKey("dbo.ShopDeliveryAddresses", new[] { "CityId", "CountryID", "DistrictId", "ShopId" });
            CreateIndex("dbo.ShopDeliveryAddresses", "ShopId");
            CreateIndex("dbo.ShopDeliveryAddresses", "DistrictId");
            CreateIndex("dbo.ShopDeliveryAddresses", "CountryID");
            CreateIndex("dbo.ShopDeliveryAddresses", "CityId");
            AddForeignKey("dbo.ShopDeliveryAddresses", "ShopId", "dbo.Shops", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ShopDeliveryAddresses", "DistrictId", "dbo.Districts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ShopDeliveryAddresses", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
