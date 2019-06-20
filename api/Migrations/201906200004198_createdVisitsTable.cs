namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdVisitsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShopVisits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Location = c.String(),
                        Shop_Id = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shop", t => t.Shop_Id)
                .Index(t => t.Shop_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopVisits", "Shop_Id", "dbo.Shop");
            DropIndex("dbo.ShopVisits", new[] { "Shop_Id" });
            DropTable("dbo.ShopVisits");
        }
    }
}
