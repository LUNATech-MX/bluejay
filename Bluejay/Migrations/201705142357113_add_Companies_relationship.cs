namespace Bluejay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Companies_relationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clave = c.String(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyUsers",
                c => new
                    {
                        ApplicationCompany_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationCompany_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.AspNetCompanies", t => t.ApplicationCompany_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.ApplicationCompany_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompanyUsers", "ApplicationCompany_Id", "dbo.AspNetCompanies");
            DropIndex("dbo.CompanyUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CompanyUsers", new[] { "ApplicationCompany_Id" });
            DropTable("dbo.CompanyUsers");
            DropTable("dbo.AspNetCompanies");
        }
    }
}
