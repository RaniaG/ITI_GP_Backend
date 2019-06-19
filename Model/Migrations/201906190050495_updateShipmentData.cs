namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateShipmentData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShipmentDatas", "fullAddress", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ShipmentDatas", "contactName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ShipmentDatas", "contactEmail", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShipmentDatas", "contactEmail", c => c.String());
            AlterColumn("dbo.ShipmentDatas", "contactName", c => c.String());
            AlterColumn("dbo.ShipmentDatas", "fullAddress", c => c.String(maxLength: 200));
        }
    }
}
