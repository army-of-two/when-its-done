namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.WorkerId)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.PhotoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.ReceivedPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        ClientId = c.Int(nullable: false),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.ClientId)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.VideoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.VitalStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BustSizeInCm = c.Int(nullable: false),
                        WaistSizeInCm = c.Int(nullable: false),
                        HipSizeInCm = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Workers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "HeightInCm", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "WeightInKg", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "BMI", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "VitalStatisticsId", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "Country", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ClientReviews", "ReviewContent", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Workers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Workers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ContactInformations", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.ContactInformations", "PhoneNumber", c => c.String(maxLength: 15));
            AlterColumn("dbo.Clients", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Clients", "LastName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Workers", "VitalStatisticsId");
            AddForeignKey("dbo.Workers", "VitalStatisticsId", "dbo.VitalStatistics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "VitalStatisticsId", "dbo.VitalStatistics");
            DropForeignKey("dbo.VideoItems", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.ReceivedPayments", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.ReceivedPayments", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.PhotoItems", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Payments", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Payments", "WorkerId", "dbo.Workers");
            DropIndex("dbo.VideoItems", new[] { "Worker_Id" });
            DropIndex("dbo.ReceivedPayments", new[] { "Worker_Id" });
            DropIndex("dbo.ReceivedPayments", new[] { "ClientId" });
            DropIndex("dbo.PhotoItems", new[] { "Worker_Id" });
            DropIndex("dbo.Payments", new[] { "Client_Id" });
            DropIndex("dbo.Payments", new[] { "WorkerId" });
            DropIndex("dbo.Workers", new[] { "VitalStatisticsId" });
            AlterColumn("dbo.Clients", "LastName", c => c.String());
            AlterColumn("dbo.Clients", "FirstName", c => c.String());
            AlterColumn("dbo.ContactInformations", "PhoneNumber", c => c.String());
            AlterColumn("dbo.ContactInformations", "Email", c => c.String());
            AlterColumn("dbo.Workers", "LastName", c => c.String());
            AlterColumn("dbo.Workers", "FirstName", c => c.String());
            AlterColumn("dbo.ClientReviews", "ReviewContent", c => c.String());
            AlterColumn("dbo.Addresses", "Street", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "Country", c => c.String());
            DropColumn("dbo.Clients", "Gender");
            DropColumn("dbo.Workers", "VitalStatisticsId");
            DropColumn("dbo.Workers", "BMI");
            DropColumn("dbo.Workers", "WeightInKg");
            DropColumn("dbo.Workers", "HeightInCm");
            DropColumn("dbo.Workers", "Gender");
            DropTable("dbo.VitalStatistics");
            DropTable("dbo.VideoItems");
            DropTable("dbo.ReceivedPayments");
            DropTable("dbo.PhotoItems");
            DropTable("dbo.Payments");
        }
    }
}
