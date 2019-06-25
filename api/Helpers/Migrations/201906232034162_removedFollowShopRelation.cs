namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedFollowShopRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FollowedShops", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.FollowedShops", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FollowedShops", new[] { "Shop_Id" });
            DropIndex("dbo.FollowedShops", new[] { "ApplicationUser_Id" });
            DropTable("dbo.FollowedShops");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FollowedShops",
                c => new
                    {
                        Shop_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Shop_Id, t.ApplicationUser_Id });
            
            CreateIndex("dbo.FollowedShops", "ApplicationUser_Id");
            CreateIndex("dbo.FollowedShops", "Shop_Id");
            AddForeignKey("dbo.FollowedShops", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FollowedShops", "Shop_Id", "dbo.Shops", "Id", cascadeDelete: true);
        }
    }
}
