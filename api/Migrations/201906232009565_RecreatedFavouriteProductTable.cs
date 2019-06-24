namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreatedFavouriteProductTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserProducts",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Product_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ApplicationUserProducts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserProducts", new[] { "Product_Id" });
            DropIndex("dbo.ApplicationUserProducts", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserProducts");
        }
    }
}
