namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShopAddressRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shop", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Shop", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Shop", "DistrictId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shop", "CountryId");
            CreateIndex("dbo.Shop", "CityId");
            CreateIndex("dbo.Shop", "DistrictId");
            AddForeignKey("dbo.Shop", "CityId", "dbo.City", "Id");
            AddForeignKey("dbo.Shop", "CountryId", "dbo.Country", "Id");
            AddForeignKey("dbo.Shop", "DistrictId", "dbo.District", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shop", "DistrictId", "dbo.District");
            DropForeignKey("dbo.Shop", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Shop", "CityId", "dbo.City");
            DropIndex("dbo.Shop", new[] { "DistrictId" });
            DropIndex("dbo.Shop", new[] { "CityId" });
            DropIndex("dbo.Shop", new[] { "CountryId" });
            DropColumn("dbo.Shop", "DistrictId");
            DropColumn("dbo.Shop", "CityId");
            DropColumn("dbo.Shop", "CountryId");
        }
    }
}
