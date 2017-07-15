namespace Bluejay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Name_Company : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Company", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Company");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
