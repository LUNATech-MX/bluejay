namespace Bluejay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ClaveEmpresa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ClaveEmpresa", c => c.String());
        }
    }
}
