namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedShopDeliveryAddressAddedShopIdasPKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShopDeliveryAddresses", "ShopId", "dbo.Shops");
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "ShopId" });
            DropPrimaryKey("dbo.ShopDeliveryAddresses");
            AlterColumn("dbo.ShopDeliveryAddresses", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ShopDeliveryAddresses", "ShopId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ShopDeliveryAddresses", new[] { "Id", "ShopId" });
            CreateIndex("dbo.ShopDeliveryAddresses", "ShopId");
            AddForeignKey("dbo.ShopDeliveryAddresses", "ShopId", "dbo.Shops", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopDeliveryAddresses", "ShopId", "dbo.Shops");
            DropIndex("dbo.ShopDeliveryAddresses", new[] { "ShopId" });
            DropPrimaryKey("dbo.ShopDeliveryAddresses");
            AlterColumn("dbo.ShopDeliveryAddresses", "ShopId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ShopDeliveryAddresses", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ShopDeliveryAddresses", "Id");
            CreateIndex("dbo.ShopDeliveryAddresses", "ShopId");
            AddForeignKey("dbo.ShopDeliveryAddresses", "ShopId", "dbo.Shops", "Id");
        }
    }
}
