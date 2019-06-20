namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdCartTableRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartProduct",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Variations = c.String(),
                        Quantity = c.Int(nullable: false)
                    })
                .PrimaryKey(t => new { t.Product_Id, t.User_Id })
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartProduct", "User_Id", "dbo.User");
            DropForeignKey("dbo.CartProduct", "Product_Id", "dbo.Product");
            DropIndex("dbo.CartProduct", new[] { "User_Id" });
            DropIndex("dbo.CartProduct", new[] { "Product_Id" });
            DropTable("dbo.CartProduct");
        }
    }
}
