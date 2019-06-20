namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullGender : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Gender", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Gender", c => c.Int(nullable: false));
        }
    }
}
