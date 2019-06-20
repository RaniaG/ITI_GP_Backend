namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedCartTableRelations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CartProduct", "Variations", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CartProduct", "Variations", c => c.String());
        }
    }
}
