namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopUserRelation : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Shop", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shop", "UserId", "dbo.User");
        }
    }
}
