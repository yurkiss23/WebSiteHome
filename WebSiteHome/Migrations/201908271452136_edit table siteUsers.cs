namespace WebSiteHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittablesiteUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblSiteUsers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblSiteUsers", "Status");
        }
    }
}
