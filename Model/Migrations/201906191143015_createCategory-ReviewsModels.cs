namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createCategoryReviewsModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Review",
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
            
            AlterColumn("dbo.Users", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropIndex("dbo.Category", new[] { "Name" });
            AlterColumn("dbo.Users", "Gender", c => c.String());
            DropTable("dbo.Review");
            DropTable("dbo.Category");
        }
    }
}
