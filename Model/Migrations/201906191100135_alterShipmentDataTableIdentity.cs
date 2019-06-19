namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterShipmentDataTableIdentity : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ShipmentDatas");
            AlterColumn("dbo.ShipmentDatas", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ShipmentDatas", new[] { "id", "user_id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ShipmentDatas");
            AlterColumn("dbo.ShipmentDatas", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ShipmentDatas", new[] { "id", "user_id" });
        }
    }
}
