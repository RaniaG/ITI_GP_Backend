namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserShopRelation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Shops");
            AlterColumn("dbo.Shops", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Shops", "Id");
            CreateIndex("dbo.Shops", "Id");
            AddForeignKey("dbo.Shops", "Id", "dbo.Users", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shops", "Id", "dbo.Users");
            DropIndex("dbo.Shops", new[] { "Id" });
            DropPrimaryKey("dbo.Shops");
            AlterColumn("dbo.Shops", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Shops", "Id");
        }
    }
}
