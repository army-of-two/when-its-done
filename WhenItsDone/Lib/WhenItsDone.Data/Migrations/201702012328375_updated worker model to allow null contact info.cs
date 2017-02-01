namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedworkermodeltoallownullcontactinfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workers", "ContactInformationId", "dbo.ContactInformations");
            DropIndex("dbo.Workers", new[] { "ContactInformationId" });
            AlterColumn("dbo.Workers", "ContactInformationId", c => c.Int());
            CreateIndex("dbo.Workers", "ContactInformationId");
            AddForeignKey("dbo.Workers", "ContactInformationId", "dbo.ContactInformations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "ContactInformationId", "dbo.ContactInformations");
            DropIndex("dbo.Workers", new[] { "ContactInformationId" });
            AlterColumn("dbo.Workers", "ContactInformationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Workers", "ContactInformationId");
            AddForeignKey("dbo.Workers", "ContactInformationId", "dbo.ContactInformations", "Id", cascadeDelete: true);
        }
    }
}
