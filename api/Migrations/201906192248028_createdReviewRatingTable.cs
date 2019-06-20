namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdReviewRatingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReviewRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Review = c.String(nullable: false, unicode: false, storeType: "text"),
                        DelieveryServiceReview = c.String(),
                        ShopServiceReview = c.String(),
                        ProductRating = c.Int(nullable: false),
                        ShopRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReviewRatings");
        }
    }
}
