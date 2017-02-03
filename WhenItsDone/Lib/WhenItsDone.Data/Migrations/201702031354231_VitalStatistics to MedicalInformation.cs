namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VitalStatisticstoMedicalInformation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workers", "VitalStatisticsId", "dbo.VitalStatistics");
            DropIndex("dbo.Workers", new[] { "VitalStatisticsId" });
            CreateTable(
                "dbo.MedicalInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BustSizeInCm = c.Int(nullable: false),
                        WaistSizeInCm = c.Int(nullable: false),
                        HipSizeInCm = c.Int(nullable: false),
                        HeightInCm = c.Int(nullable: false),
                        WeightInKg = c.Int(nullable: false),
                        BMI = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Workers", "MedicalInformationId", c => c.Int());
            CreateIndex("dbo.Workers", "MedicalInformationId");
            AddForeignKey("dbo.Workers", "MedicalInformationId", "dbo.MedicalInformations", "Id");
            DropColumn("dbo.Workers", "HeightInCm");
            DropColumn("dbo.Workers", "WeightInKg");
            DropColumn("dbo.Workers", "BMI");
            DropColumn("dbo.Workers", "VitalStatisticsId");
            DropTable("dbo.VitalStatistics");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Workers", "VitalStatisticsId", c => c.Int());
            AddColumn("dbo.Workers", "BMI", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "WeightInKg", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "HeightInCm", c => c.Int(nullable: false));
            DropForeignKey("dbo.Workers", "MedicalInformationId", "dbo.MedicalInformations");
            DropIndex("dbo.Workers", new[] { "MedicalInformationId" });
            DropColumn("dbo.Workers", "MedicalInformationId");
            DropTable("dbo.MedicalInformations");
            CreateIndex("dbo.Workers", "VitalStatisticsId");
            AddForeignKey("dbo.Workers", "VitalStatisticsId", "dbo.VitalStatistics", "Id");
        }
    }
}
