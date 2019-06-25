namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserShopRelation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ShopId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ShopId", c => c.String(maxLength: 128));
        }
    }
}
