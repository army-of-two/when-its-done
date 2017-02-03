namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedusermodeltoallownullrating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workers", "VitalStatisticsId", "dbo.VitalStatistics");
            DropForeignKey("dbo.Clients", "ContactInformationId", "dbo.ContactInformations");
            DropIndex("dbo.Workers", new[] { "VitalStatisticsId" });
            DropIndex("dbo.Clients", new[] { "ContactInformationId" });
            AddColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Gender", c => c.Int());
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "HeightInCm", c => c.Int());
            AlterColumn("dbo.Workers", "WeightInKg", c => c.Int());
            AlterColumn("dbo.Workers", "VitalStatisticsId", c => c.Int());
            AlterColumn("dbo.Clients", "ContactInformationId", c => c.Int());
            CreateIndex("dbo.Workers", "VitalStatisticsId");
            CreateIndex("dbo.Clients", "ContactInformationId");
            AddForeignKey("dbo.Workers", "VitalStatisticsId", "dbo.VitalStatistics", "Id");
            AddForeignKey("dbo.Clients", "ContactInformationId", "dbo.ContactInformations", "Id");
            DropColumn("dbo.Workers", "FirstName");
            DropColumn("dbo.Workers", "LastName");
            DropColumn("dbo.Workers", "Gender");
            DropColumn("dbo.Workers", "Age");
            DropColumn("dbo.Workers", "Rating");
            DropColumn("dbo.Clients", "FirstName");
            DropColumn("dbo.Clients", "LastName");
            DropColumn("dbo.Clients", "Gender");
            DropColumn("dbo.Clients", "Age");
            DropColumn("dbo.Clients", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Clients", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Workers", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Workers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Clients", "ContactInformationId", "dbo.ContactInformations");
            DropForeignKey("dbo.Workers", "VitalStatisticsId", "dbo.VitalStatistics");
            DropIndex("dbo.Clients", new[] { "ContactInformationId" });
            DropIndex("dbo.Workers", new[] { "VitalStatisticsId" });
            AlterColumn("dbo.Clients", "ContactInformationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "VitalStatisticsId", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "WeightInKg", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "HeightInCm", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Age");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            CreateIndex("dbo.Clients", "ContactInformationId");
            CreateIndex("dbo.Workers", "VitalStatisticsId");
            AddForeignKey("dbo.Clients", "ContactInformationId", "dbo.ContactInformations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Workers", "VitalStatisticsId", "dbo.VitalStatistics", "Id", cascadeDelete: true);
        }
    }
}
