namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedReviewRatingTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "User");
            AlterColumn("dbo.ReviewRatings", "Review", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReviewRatings", "Review", c => c.String(nullable: false, unicode: false, storeType: "text"));
            RenameTable(name: "dbo.User", newName: "Users");
        }
    }
}
