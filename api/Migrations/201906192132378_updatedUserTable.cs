namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedUserTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "Photo", c => c.String());
            AddColumn("dbo.Users", "CoverPhoto", c => c.String());
            AddColumn("dbo.Users", "Biography", c => c.String());
            AddColumn("dbo.Users", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Biography");
            DropColumn("dbo.Users", "CoverPhoto");
            DropColumn("dbo.Users", "Photo");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
        }
    }
}
