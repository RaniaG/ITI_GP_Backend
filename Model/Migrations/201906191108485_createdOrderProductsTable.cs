namespace model.Migrations
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
                        order_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                        variations = c.String(maxLength: 200),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.order_id, t.product_id })
                .ForeignKey("dbo.Orders", t => t.order_id)
                .ForeignKey("dbo.Products", t => t.product_id)
                .Index(t => t.order_id)
                .Index(t => t.product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "product_id", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "order_id", "dbo.Orders");
            DropIndex("dbo.OrderProducts", new[] { "product_id" });
            DropIndex("dbo.OrderProducts", new[] { "order_id" });
            DropTable("dbo.OrderProducts");
        }
    }
}
