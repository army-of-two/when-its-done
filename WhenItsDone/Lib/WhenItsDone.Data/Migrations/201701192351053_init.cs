namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewContent = c.String(),
                        Score = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Rating = c.Int(nullable: false),
                        ContactInformationId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactInformations", t => t.ContactInformationId, cascadeDelete: false)
                .Index(t => t.ContactInformationId);
            
            CreateTable(
                "dbo.ContactInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduledTime = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WorkerId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Rating = c.Int(nullable: false),
                        ContactInformationId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactInformations", t => t.ContactInformationId, cascadeDelete: true)
                .Index(t => t.ContactInformationId);
            
            CreateTable(
                "dbo.WorkerReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewContent = c.String(),
                        Score = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerReviews", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientReviews", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Jobs", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Jobs", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ContactInformationId", "dbo.ContactInformations");
            DropForeignKey("dbo.Workers", "ContactInformationId", "dbo.ContactInformations");
            DropForeignKey("dbo.ContactInformations", "AddressId", "dbo.Addresses");
            DropIndex("dbo.WorkerReviews", new[] { "ClientId" });
            DropIndex("dbo.Clients", new[] { "ContactInformationId" });
            DropIndex("dbo.Jobs", new[] { "ClientId" });
            DropIndex("dbo.Jobs", new[] { "WorkerId" });
            DropIndex("dbo.ContactInformations", new[] { "AddressId" });
            DropIndex("dbo.Workers", new[] { "ContactInformationId" });
            DropIndex("dbo.ClientReviews", new[] { "WorkerId" });
            DropTable("dbo.WorkerReviews");
            DropTable("dbo.Clients");
            DropTable("dbo.Jobs");
            DropTable("dbo.ContactInformations");
            DropTable("dbo.Workers");
            DropTable("dbo.ClientReviews");
            DropTable("dbo.Addresses");
        }
    }
}
