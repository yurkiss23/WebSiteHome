namespace WebSiteHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablesiteUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblSiteUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        DateBirth = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblSiteUsers");
        }
    }
}
