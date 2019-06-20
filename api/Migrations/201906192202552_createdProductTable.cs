namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdProductTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Price = c.Double(nullable: false),
                        Discount = c.Double(),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        Terms = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        MinDeliveryTime = c.Int(nullable: false),
                        MaxDeliveryTime = c.Int(nullable: false),
                        Variations = c.String(),
                        Rating = c.Double(nullable: false),
                        Images = c.String(),
                        PublishTime = c.DateTime(),
                        LifeTime = c.Int(),
                        Active = c.Boolean(nullable: false),
                        Approved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
