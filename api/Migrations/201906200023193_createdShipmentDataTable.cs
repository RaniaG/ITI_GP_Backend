namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdShipmentDataTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipmentDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        FullAddress = c.String(nullable: false, maxLength: 200),
                        PostalCode = c.Int(),
                        ContactPhone = c.String(nullable: false, maxLength: 20),
                        ContactName = c.String(nullable: false, maxLength: 100),
                        ContactEmail = c.String(nullable: false, maxLength: 50),
                        CityId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.UserId })
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .ForeignKey("dbo.District", t => t.DistrictId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CityId)
                .Index(t => t.CountryId)
                .Index(t => t.DistrictId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipmentDatas", "UserId", "dbo.User");
            DropForeignKey("dbo.ShipmentDatas", "DistrictId", "dbo.District");
            DropForeignKey("dbo.ShipmentDatas", "CountryId", "dbo.Country");
            DropForeignKey("dbo.ShipmentDatas", "CityId", "dbo.City");
            DropIndex("dbo.ShipmentDatas", new[] { "DistrictId" });
            DropIndex("dbo.ShipmentDatas", new[] { "CountryId" });
            DropIndex("dbo.ShipmentDatas", new[] { "CityId" });
            DropIndex("dbo.ShipmentDatas", new[] { "UserId" });
            DropTable("dbo.ShipmentDatas");
        }
    }
}
