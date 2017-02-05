namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedContactInformation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactInformations", "AddressId", "dbo.Addresses");
            DropIndex("dbo.ContactInformations", new[] { "AddressId" });
            AlterColumn("dbo.ContactInformations", "AddressId", c => c.Int());
            CreateIndex("dbo.ContactInformations", "AddressId");
            AddForeignKey("dbo.ContactInformations", "AddressId", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactInformations", "AddressId", "dbo.Addresses");
            DropIndex("dbo.ContactInformations", new[] { "AddressId" });
            AlterColumn("dbo.ContactInformations", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactInformations", "AddressId");
            AddForeignKey("dbo.ContactInformations", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
