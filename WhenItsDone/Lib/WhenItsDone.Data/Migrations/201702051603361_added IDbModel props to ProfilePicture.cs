namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIDbModelpropstoProfilePicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfilePictures", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfilePictures", "IsDeleted");
        }
    }
}
