namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdShopsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Photo = c.String(),
                        Cover = c.String(),
                        Rating = c.Int(nullable: false),
                        About = c.String(),
                        Policy = c.String(nullable: false),
                        Subscription = c.Int(nullable: false),
                        PostalCode = c.String(),
                        Street = c.String(),
                    })
                    .Index(sh => sh.Name, unique: true)
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Shops", "Name");
            DropTable("dbo.Shops");
        }
    }
}
