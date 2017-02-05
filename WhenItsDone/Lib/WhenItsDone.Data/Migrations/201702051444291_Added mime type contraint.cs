namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedmimetypecontraint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProfilePictures", "MimeType", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProfilePictures", "MimeType", c => c.String(nullable: false));
        }
    }
}
