namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCountryCityDistrictTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Shops", "City_Id", c => c.Int());
            AddColumn("dbo.Shops", "Country_Id", c => c.Int());
            AddColumn("dbo.Shops", "District_Id", c => c.Int());
            CreateIndex("dbo.Shops", "City_Id");
            CreateIndex("dbo.Shops", "Country_Id");
            CreateIndex("dbo.Shops", "District_Id");
            AddForeignKey("dbo.Shops", "City_Id", "dbo.City", "Id");
            AddForeignKey("dbo.Shops", "Country_Id", "dbo.Country", "Id");
            AddForeignKey("dbo.Shops", "District_Id", "dbo.District", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shops", "District_Id", "dbo.District");
            DropForeignKey("dbo.Shops", "Country_Id", "dbo.Country");
            DropForeignKey("dbo.Shops", "City_Id", "dbo.City");
            DropIndex("dbo.Shops", new[] { "District_Id" });
            DropIndex("dbo.Shops", new[] { "Country_Id" });
            DropIndex("dbo.Shops", new[] { "City_Id" });
            DropColumn("dbo.Shops", "District_Id");
            DropColumn("dbo.Shops", "Country_Id");
            DropColumn("dbo.Shops", "City_Id");
            DropTable("dbo.District");
            DropTable("dbo.Country");
            DropTable("dbo.City");
        }
    }
}
