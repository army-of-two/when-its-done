namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedProfilePicturemodelwithPictureUrlprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfilePictures", "PictureUrl", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfilePictures", "PictureUrl");
        }
    }
}
