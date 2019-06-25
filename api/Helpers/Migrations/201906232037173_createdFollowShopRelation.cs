namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdFollowShopRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShopApplicationUsers",
                c => new
                    {
                        Shop_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Shop_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Shops", t => t.Shop_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Shop_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShopApplicationUsers", "Shop_Id", "dbo.Shops");
            DropIndex("dbo.ShopApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ShopApplicationUsers", new[] { "Shop_Id" });
            DropTable("dbo.ShopApplicationUsers");
        }
    }
}
