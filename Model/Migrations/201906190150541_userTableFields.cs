namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userTableFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Fname", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "Lname", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Users", "Photo", c => c.String());
            AddColumn("dbo.Users", "CoverPhoto", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Users", "Biography", c => c.String());
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Users", "UserName", unique: true);
            CreateIndex("dbo.Users", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Biography");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "CoverPhoto");
            DropColumn("dbo.Users", "Photo");
            DropColumn("dbo.Users", "UserName");
            DropColumn("dbo.Users", "Lname");
            DropColumn("dbo.Users", "Fname");
        }
    }
}
