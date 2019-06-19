namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateShopTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Photo = c.String(nullable: false),
                        Cover = c.String(),
                        Rating = c.Int(nullable: false),
                        About = c.String(),
                        Policy = c.String(nullable: false),
                        Subscription = c.Int(nullable: false),
                        PostalCode = c.String(),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            AlterColumn("dbo.Users", "Photo", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "CoverPhoto", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropIndex("dbo.Shops", new[] { "Name" });
            AlterColumn("dbo.Users", "CoverPhoto", c => c.String());
            AlterColumn("dbo.Users", "Photo", c => c.String());
            DropTable("dbo.Shops");
        }
    }
}
