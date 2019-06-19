namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedShipmentDataRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipmentDatas", "city_id", c => c.Int(nullable: false));
            AddColumn("dbo.ShipmentDatas", "country_id", c => c.Int(nullable: false));
            AddColumn("dbo.ShipmentDatas", "district_id", c => c.Int(nullable: false));
            CreateIndex("dbo.ShipmentDatas", "id");
            AddForeignKey("dbo.ShipmentDatas", "city_id", "dbo.City", "Id");
            AddForeignKey("dbo.ShipmentDatas", "country_id", "dbo.Country", "Id");
            AddForeignKey("dbo.ShipmentDatas", "district_id", "dbo.District", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipmentDatas", "district_id", "dbo.District");
            DropForeignKey("dbo.ShipmentDatas", "country_id", "dbo.Country");
            DropForeignKey("dbo.ShipmentDatas", "city_id", "dbo.City");
            DropIndex("dbo.ShipmentDatas", new[] { "id" });
            DropColumn("dbo.ShipmentDatas", "district_id");
            DropColumn("dbo.ShipmentDatas", "country_id");
            DropColumn("dbo.ShipmentDatas", "city_id");
        }
    }
}
