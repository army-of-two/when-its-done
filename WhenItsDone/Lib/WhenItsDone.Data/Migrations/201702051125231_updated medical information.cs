namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmedicalinformation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedicalInformations", "BustSizeInCm", c => c.Int());
            AlterColumn("dbo.MedicalInformations", "WaistSizeInCm", c => c.Int());
            AlterColumn("dbo.MedicalInformations", "HipSizeInCm", c => c.Int());
            AlterColumn("dbo.MedicalInformations", "HeightInCm", c => c.Int());
            AlterColumn("dbo.MedicalInformations", "WeightInKg", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicalInformations", "WeightInKg", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicalInformations", "HeightInCm", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicalInformations", "HipSizeInCm", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicalInformations", "WaistSizeInCm", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicalInformations", "BustSizeInCm", c => c.Int(nullable: false));
        }
    }
}
