namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderTableRelations : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Order");
            AddColumn("dbo.Order", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Order", "ShippingDataId", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Order", "Id");
            AddForeignKey("dbo.Order", new[] { "ShippingDataId", "UserId" }, "dbo.ShipmentDatas", new[] { "Id", "UserId" });
            AddForeignKey("dbo.Order", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.Order", new[] { "ShippingDataId", "UserId" }, "dbo.ShipmentDatas");
            DropPrimaryKey("dbo.Order");
            AlterColumn("dbo.Order", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Order", "ShippingDataId");
            DropColumn("dbo.Order", "UserId");
            AddPrimaryKey("dbo.Order", "Id");
        }
    }
}
