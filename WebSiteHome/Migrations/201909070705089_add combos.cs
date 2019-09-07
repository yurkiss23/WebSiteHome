namespace WebSiteHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcombos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCombos",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Image = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblCombos", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.tblCombos", new[] { "Id" });
            DropTable("dbo.tblCombos");
        }
    }
}
