namespace WebSiteHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcombo : DbMigration
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
            
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropTable("dbo.tblSiteUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tblSiteUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        DateBirth = c.DateTime(nullable: false),
                        DateAdd = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(maxLength: 255),
                        Status = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.tblCombos", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.tblCombos", new[] { "Id" });
            DropTable("dbo.tblCombos");
        }
    }
}
