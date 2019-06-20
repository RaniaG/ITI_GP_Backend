namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdOrderProductsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Variations = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Order");
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropTable("dbo.OrderProducts");
        }
    }
}
