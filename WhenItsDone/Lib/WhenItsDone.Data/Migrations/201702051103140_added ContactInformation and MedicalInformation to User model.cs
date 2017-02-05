namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedContactInformationandMedicalInformationtoUsermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "MedicalInformationId", c => c.Int());
            AddColumn("dbo.Users", "ContactInformationId", c => c.Int());
            AddColumn("dbo.WorkerReviews", "Dish_Id", c => c.Int());
            AlterColumn("dbo.Users", "Rating", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkerReviews", "Dish_Id");
            CreateIndex("dbo.Users", "MedicalInformationId");
            CreateIndex("dbo.Users", "ContactInformationId");
            AddForeignKey("dbo.WorkerReviews", "Dish_Id", "dbo.Dishes", "Id");
            AddForeignKey("dbo.Users", "ContactInformationId", "dbo.ContactInformations", "Id");
            AddForeignKey("dbo.Users", "MedicalInformationId", "dbo.MedicalInformations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "MedicalInformationId", "dbo.MedicalInformations");
            DropForeignKey("dbo.Users", "ContactInformationId", "dbo.ContactInformations");
            DropForeignKey("dbo.WorkerReviews", "Dish_Id", "dbo.Dishes");
            DropIndex("dbo.Users", new[] { "ContactInformationId" });
            DropIndex("dbo.Users", new[] { "MedicalInformationId" });
            DropIndex("dbo.WorkerReviews", new[] { "Dish_Id" });
            AlterColumn("dbo.Users", "Rating", c => c.Int());
            DropColumn("dbo.WorkerReviews", "Dish_Id");
            DropColumn("dbo.Users", "ContactInformationId");
            DropColumn("dbo.Users", "MedicalInformationId");
        }
    }
}
