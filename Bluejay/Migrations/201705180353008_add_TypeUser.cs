namespace Bluejay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_TypeUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TypeUser", c => c.String());
            DropColumn("dbo.AspNetUsers", "Company");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Company", c => c.String());
            DropColumn("dbo.AspNetUsers", "TypeUser");
        }
    }
}
