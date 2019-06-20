namespace api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                    .Index(t=>t.Name,unique:true)
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", "Name");
            DropTable("dbo.Categories");
        }
    }
}
