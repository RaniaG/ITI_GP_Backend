namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createFollowShopRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FollowedShops",
                c => new
                    {
                        Shop_UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Shop_UserId, t.ApplicationUser_Id })
                .ForeignKey("dbo.Shop", t => t.Shop_UserId)
                .ForeignKey("dbo.User", t => t.ApplicationUser_Id)
                .Index(t => t.Shop_UserId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FollowedShops", "ApplicationUser_Id", "dbo.User");
            DropForeignKey("dbo.FollowedShops", "Shop_UserId", "dbo.Shop");
            DropIndex("dbo.FollowedShops", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FollowedShops", new[] { "Shop_UserId" });
            DropTable("dbo.FollowedShops");
        }
    }
}
