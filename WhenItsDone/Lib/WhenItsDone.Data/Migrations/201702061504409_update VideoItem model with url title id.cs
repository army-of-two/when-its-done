namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateVideoItemmodelwithurltitleid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoItems", "Title", c => c.String());
            AddColumn("dbo.VideoItems", "YouTubeUrl", c => c.String(nullable: false, maxLength: 300));
            AddColumn("dbo.VideoItems", "YouTubeId", c => c.String());
            DropColumn("dbo.VideoItems", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VideoItems", "Url", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.VideoItems", "YouTubeId");
            DropColumn("dbo.VideoItems", "YouTubeUrl");
            DropColumn("dbo.VideoItems", "Title");
        }
    }
}
