namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedProfilePicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfilePictures", "MimeType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfilePictures", "MimeType");
        }
    }
}
