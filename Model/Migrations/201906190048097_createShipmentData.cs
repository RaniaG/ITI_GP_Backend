namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createShipmentData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipmentDatas",
                c => new
                    {
                        id = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                        fullAddress = c.String(maxLength: 200),
                        postalCode = c.Int(),
                        contactPhone = c.Long(nullable: false),
                        contactName = c.String(),
                        contactEmail = c.String(),
                    })
                .PrimaryKey(t => new { t.id, t.user_id })
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipmentDatas", "user_id", "dbo.Users");
            DropIndex("dbo.ShipmentDatas", new[] { "user_id" });
            DropTable("dbo.Users");
            DropTable("dbo.ShipmentDatas");
        }
    }
}
