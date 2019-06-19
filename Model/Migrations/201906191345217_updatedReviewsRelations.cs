namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedReviewsRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "user_id", c => c.Int(nullable: false));
            AddColumn("dbo.Review", "product_id", c => c.Int(nullable: false));
            AddColumn("dbo.Review", "shop_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "product_id");
            CreateIndex("dbo.Review", "shop_Id");
            CreateIndex("dbo.Review", "user_id");
            AddForeignKey("dbo.Review", "product_id", "dbo.Products", "id");
            AddForeignKey("dbo.Review", "shop_Id", "dbo.Shops", "Id");
            AddForeignKey("dbo.Review", "user_id", "dbo.Users", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "user_id", "dbo.Users");
            DropForeignKey("dbo.Review", "shop_Id", "dbo.Shops");
            DropForeignKey("dbo.Review", "product_id", "dbo.Products");
            DropIndex("dbo.Review", new[] { "user_id" });
            DropIndex("dbo.Review", new[] { "shop_Id" });
            DropIndex("dbo.Review", new[] { "product_id" });
            DropColumn("dbo.Review", "shop_id");
            DropColumn("dbo.Review", "product_id");
            DropColumn("dbo.Review", "user_id");
        }
    }
}
