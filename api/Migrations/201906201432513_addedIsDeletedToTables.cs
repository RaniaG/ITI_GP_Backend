namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsDeletedToTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartProduct", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Shop", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Order", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "IsDeleted");
            DropColumn("dbo.Shop", "IsDeleted");
            DropColumn("dbo.CartProduct", "IsDeleted");
        }
    }
}
