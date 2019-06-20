namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryCityDistrictRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.City", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.District", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.City", "CountryId");
            CreateIndex("dbo.District", "CityId");
            AddForeignKey("dbo.City", "CountryId", "dbo.Country", "Id");
            AddForeignKey("dbo.District", "CityId", "dbo.City", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.District", "CityId", "dbo.City");
            DropForeignKey("dbo.City", "CountryId", "dbo.Country");
            DropIndex("dbo.District", new[] { "CityId" });
            DropIndex("dbo.City", new[] { "CountryId" });
            DropColumn("dbo.District", "CityId");
            DropColumn("dbo.City", "CountryId");
        }
    }
}
