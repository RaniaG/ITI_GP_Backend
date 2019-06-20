namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewRatingRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewRating", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ReviewRating", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.ReviewRating", "ShopId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ReviewRating", "UserId");
            CreateIndex("dbo.ReviewRating", "ProductId");
            AddForeignKey("dbo.ReviewRating", "ProductId", "dbo.Product", "Id");
            AddForeignKey("dbo.ReviewRating", "ShopId", "dbo.Shop", "UserId");
            AddForeignKey("dbo.ReviewRating", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewRating", "UserId", "dbo.User");
            DropForeignKey("dbo.ReviewRating", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.ReviewRating", "ProductId", "dbo.Product");
            DropIndex("dbo.ReviewRating", new[] { "ProductId" });
            DropIndex("dbo.ReviewRating", new[] { "UserId" });
            DropColumn("dbo.ReviewRating", "ShopId");
            DropColumn("dbo.ReviewRating", "ProductId");
            DropColumn("dbo.ReviewRating", "UserId");
        }
    }
}
