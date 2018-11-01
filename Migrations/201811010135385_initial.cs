namespace IndygoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        CompanyPhone = c.String(maxLength: 20),
                        CompanyWebsite = c.String(maxLength: 40),
                        CompanyStreetAddress = c.String(maxLength: 40),
                        CompanyCity = c.String(maxLength: 25),
                        CompanyCountry = c.String(maxLength: 45),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        TokenId = c.String(nullable: false, maxLength: 128),
                        TimeCreated = c.DateTime(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                        Company_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.TokenId)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .Index(t => t.Company_CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "Company_CompanyId", "dbo.Companies");
            DropIndex("dbo.Tokens", new[] { "Company_CompanyId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Companies");
        }
    }
}
