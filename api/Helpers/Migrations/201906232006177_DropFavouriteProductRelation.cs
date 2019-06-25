namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropFavouriteProductRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavouriteProducts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavouriteProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.FavouriteProducts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FavouriteProducts", new[] { "Product_Id" });
            DropTable("dbo.FavouriteProducts");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.FavouriteProducts",
                c => new
                {
                    ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    Product_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Product_Id });

            CreateIndex("dbo.FavouriteProducts", "Product_Id");
            CreateIndex("dbo.FavouriteProducts", "ApplicationUser_Id");
            AddForeignKey("dbo.FavouriteProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FavouriteProducts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
