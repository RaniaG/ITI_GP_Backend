namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPriceToPackageAndOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packages", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Price");
            DropColumn("dbo.Packages", "Price");
        }
    }
}
