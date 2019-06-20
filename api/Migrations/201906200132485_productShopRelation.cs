namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productShopRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ShopId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Product", "ShopId");
            AddForeignKey("dbo.Product", "ShopId", "dbo.Shop", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ShopId", "dbo.Shop");
            DropIndex("dbo.Product", new[] { "ShopId" });
            DropColumn("dbo.Product", "ShopId");
        }
    }
}
