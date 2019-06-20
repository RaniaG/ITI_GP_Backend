namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedAllTableNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.Cities", newName: "City");
            RenameTable(name: "dbo.Countries", newName: "Country");
            RenameTable(name: "dbo.Districts", newName: "District");
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.ReviewRatings", newName: "ReviewRating");
            RenameTable(name: "dbo.Shops", newName: "Shop");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Shop", newName: "Shops");
            RenameTable(name: "dbo.ReviewRating", newName: "ReviewRatings");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameTable(name: "dbo.District", newName: "Districts");
            RenameTable(name: "dbo.Country", newName: "Countries");
            RenameTable(name: "dbo.City", newName: "Cities");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
