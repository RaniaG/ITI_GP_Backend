namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdPackageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ShopId = c.String(nullable: false, maxLength: 128),
                        Status = c.Int(nullable: false),
                        DeliveryTime = c.DateTime(nullable: false)
                    })
                .PrimaryKey(t => new { t.Id, t.OrderId, t.ShopId })
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .Index(t => t.OrderId)
                .Index(t => t.ShopId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.Packages", "OrderId", "dbo.Order");
            DropIndex("dbo.Packages", new[] { "ShopId" });
            DropIndex("dbo.Packages", new[] { "OrderId" });
            DropTable("dbo.Packages");
        }
    }
}
