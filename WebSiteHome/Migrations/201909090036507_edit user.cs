namespace WebSiteHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edituser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblSiteUsers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblSiteUsers", "Password", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
