namespace model.Migrations
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
                        order_id = c.Int(nullable: false),
                        shop_id = c.Int(nullable: false),
                        id = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        deliveryTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.order_id, t.shop_id, t.id })
                .ForeignKey("dbo.Orders", t => t.order_id)
                .ForeignKey("dbo.Shops", t => t.shop_id)
                .Index(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "id", "dbo.Shops");
            DropForeignKey("dbo.Packages", "id", "dbo.Orders");
            DropIndex("dbo.Packages", new[] { "id" });
            DropTable("dbo.Packages");
        }
    }
}
