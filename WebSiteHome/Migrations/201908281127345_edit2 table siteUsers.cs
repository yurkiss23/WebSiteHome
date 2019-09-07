namespace WebSiteHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit2tablesiteUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblSiteUsers", "DateAdd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblSiteUsers", "DateAdd");
        }
    }
}
