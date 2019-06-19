namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productTableRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "shop_id", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "category_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "category_Id");
            CreateIndex("dbo.Products", "shop_Id");
            AddForeignKey("dbo.Products", "category_Id", "dbo.Category", "Id");
            AddForeignKey("dbo.Products", "shop_Id", "dbo.Shops", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "shop_Id", "dbo.Shops");
            DropForeignKey("dbo.Products", "category_Id", "dbo.Category");
            DropIndex("dbo.Products", new[] { "shop_Id" });
            DropIndex("dbo.Products", new[] { "category_Id" });
            DropColumn("dbo.Products", "category_id");
            DropColumn("dbo.Products", "shop_id");
        }
    }
}
