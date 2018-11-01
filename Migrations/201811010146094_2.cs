namespace IndygoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KeycodeBans",
                c => new
                    {
                        KeycodeId = c.String(nullable: false, maxLength: 30),
                        TokenId = c.String(nullable: false, maxLength: 128),
                        BanDate = c.DateTime(nullable: false),
                        BanReason = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KeycodeId)
                .ForeignKey("dbo.Keycodes", t => t.KeycodeId)
                .ForeignKey("dbo.Tokens", t => t.TokenId, cascadeDelete: true)
                .Index(t => t.KeycodeId)
                .Index(t => t.TokenId);
            
            CreateTable(
                "dbo.Keycodes",
                c => new
                    {
                        KeycodeId = c.String(nullable: false, maxLength: 30),
                        TokenId = c.String(nullable: false, maxLength: 128),
                        MaxRegistrations = c.Int(nullable: false),
                        ExpirationLength = c.Int(nullable: false),
                        Package = c.Byte(nullable: false),
                        IsBanned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KeycodeId)
                .ForeignKey("dbo.Tokens", t => t.TokenId, cascadeDelete: true)
                .Index(t => t.TokenId);
            
            CreateTable(
                "dbo.KeyRegistrations",
                c => new
                    {
                        KeycodeId = c.String(nullable: false, maxLength: 30),
                        TokenId = c.String(nullable: false, maxLength: 128),
                        RegistrationDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        IPAddress = c.String(),
                    })
                .PrimaryKey(t => t.KeycodeId)
                .ForeignKey("dbo.Keycodes", t => t.KeycodeId)
                .ForeignKey("dbo.Tokens", t => t.TokenId, cascadeDelete: true)
                .Index(t => t.KeycodeId)
                .Index(t => t.TokenId);
            
            CreateTable(
                "dbo.SoftwareBans",
                c => new
                    {
                        TokenId = c.String(nullable: false, maxLength: 128),
                        BanReason = c.String(maxLength: 45),
                        BanDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TokenId)
                .ForeignKey("dbo.Tokens", t => t.TokenId)
                .Index(t => t.TokenId);
            
            CreateTable(
                "dbo.Softwares",
                c => new
                    {
                        TokenId = c.String(nullable: false, maxLength: 128),
                        LatestVersion = c.String(maxLength: 25),
                        UseAutomaticUpdates = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TokenId)
                .ForeignKey("dbo.Tokens", t => t.TokenId)
                .Index(t => t.TokenId);
            
            CreateTable(
                "dbo.UserCompanies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 25),
                        UserAccessLevel = c.Byte(nullable: false),
                        UserTitle = c.String(maxLength: 40),
                        IsActiveUser = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Users", t => t.Username, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 75),
                        Email = c.String(nullable: false, maxLength: 75),
                        DateRegistered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCompanies", "Username", "dbo.Users");
            DropForeignKey("dbo.UserCompanies", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Softwares", "TokenId", "dbo.Tokens");
            DropForeignKey("dbo.SoftwareBans", "TokenId", "dbo.Tokens");
            DropForeignKey("dbo.KeyRegistrations", "TokenId", "dbo.Tokens");
            DropForeignKey("dbo.KeyRegistrations", "KeycodeId", "dbo.Keycodes");
            DropForeignKey("dbo.KeycodeBans", "TokenId", "dbo.Tokens");
            DropForeignKey("dbo.KeycodeBans", "KeycodeId", "dbo.Keycodes");
            DropForeignKey("dbo.Keycodes", "TokenId", "dbo.Tokens");
            DropIndex("dbo.UserCompanies", new[] { "Username" });
            DropIndex("dbo.UserCompanies", new[] { "CompanyId" });
            DropIndex("dbo.Softwares", new[] { "TokenId" });
            DropIndex("dbo.SoftwareBans", new[] { "TokenId" });
            DropIndex("dbo.KeyRegistrations", new[] { "TokenId" });
            DropIndex("dbo.KeyRegistrations", new[] { "KeycodeId" });
            DropIndex("dbo.Keycodes", new[] { "TokenId" });
            DropIndex("dbo.KeycodeBans", new[] { "TokenId" });
            DropIndex("dbo.KeycodeBans", new[] { "KeycodeId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserCompanies");
            DropTable("dbo.Softwares");
            DropTable("dbo.SoftwareBans");
            DropTable("dbo.KeyRegistrations");
            DropTable("dbo.Keycodes");
            DropTable("dbo.KeycodeBans");
        }
    }
}
