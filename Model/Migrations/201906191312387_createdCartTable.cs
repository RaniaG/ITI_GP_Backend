namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdCartTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                        variations = c.String(),
                        quantity = c.Int(nullable: false)
                    })
                .PrimaryKey(t => new { t.product_id, t.user_id })
                .ForeignKey("dbo.Products", t => t.product_id)
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => t.product_id)
                .Index(t => t.user_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "user_id", "dbo.Users");
            DropForeignKey("dbo.Carts", "product_id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "user_id" });
            DropIndex("dbo.Carts", new[] { "product_id" });
            DropTable("dbo.Carts");
        }
    }
}
