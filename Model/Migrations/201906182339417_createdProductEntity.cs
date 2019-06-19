namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdProductEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                        price = c.Double(nullable: false,defaultValue:0),
                        discount = c.Double(),
                        quantity = c.Int(nullable: false),
                        description = c.String(),
                        terms = c.String(),
                        isDeleted = c.Boolean(nullable: false,defaultValue:false),
                        minDeliveryTime = c.Int(nullable: false),
                        maxDeliveryTime = c.Int(nullable: false),
                        variations = c.String(),
                        rating = c.Double(nullable: false,defaultValue:0),
                        images = c.String(),
                        publishTime = c.DateTime(),
                        lifeTime = c.Int(),
                        active = c.Boolean(nullable: false,defaultValue:false),
                        approved = c.Boolean(nullable: false,defaultValue:false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
