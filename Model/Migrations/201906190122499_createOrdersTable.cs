namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createOrdersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                {
                    id = c.Int(nullable: false),
                    paymentMethod = c.Int(nullable: false),
                    date = c.DateTime(nullable: false),
                    status = c.Int(nullable: false),
                    user_id = c.Int(nullable: false),
                    shippingData_id = c.Int(nullable: false)
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ShipmentDatas", t => new { t.id, t.user_id })
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => new { t.id, t.user_id });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "user_id1", "dbo.Users");
            DropForeignKey("dbo.Orders", new[] { "id", "user_id" }, "dbo.ShipmentDatas");
            DropIndex("dbo.Orders", new[] { "user_id1" });
            DropIndex("dbo.Orders", new[] { "id", "user_id" });
            DropTable("dbo.Orders");
        }
    }
}
