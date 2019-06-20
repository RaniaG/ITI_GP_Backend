namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favouriteProductsRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavouriteProducts",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Product_Id })
                .ForeignKey("dbo.User", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavouriteProducts", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.FavouriteProducts", "ApplicationUser_Id", "dbo.User");
            DropIndex("dbo.FavouriteProducts", new[] { "Product_Id" });
            DropIndex("dbo.FavouriteProducts", new[] { "ApplicationUser_Id" });
            DropTable("dbo.FavouriteProducts");
        }
    }
}
