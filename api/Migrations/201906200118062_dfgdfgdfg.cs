namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfgdfgdfg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShopVisits", "Shop_Id", "dbo.Shop");
            DropIndex("dbo.ShopVisits", new[] { "Shop_Id" });
            DropPrimaryKey("dbo.Shop");
            AddColumn("dbo.Shop", "UserId", c => c.String(nullable: false, maxLength: 128));
            
            AlterColumn("dbo.ShopVisits", "Shop_Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Shop", "UserId");
            CreateIndex("dbo.ShopVisits", "Shop_Id");
            AddForeignKey("dbo.ShopVisits", "Shop_Id", "dbo.Shop", "UserId");
            DropColumn("dbo.Shop", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shop", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ShopVisits", "Shop_Id", "dbo.Shop");
            DropIndex("dbo.ShopVisits", new[] { "Shop_Id" });
            DropPrimaryKey("dbo.Shop");
            AlterColumn("dbo.ShopVisits", "Shop_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Shop", "UserId");
            AddPrimaryKey("dbo.Shop", "Id");
            CreateIndex("dbo.ShopVisits", "Shop_Id");
            AddForeignKey("dbo.ShopVisits", "Shop_Id", "dbo.Shop", "Id", cascadeDelete: true);
        }
    }
}
