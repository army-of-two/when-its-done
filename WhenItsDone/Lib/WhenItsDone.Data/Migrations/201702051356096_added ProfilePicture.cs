namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProfilePicture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfilePictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureBase64 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "ProfilePictureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "ProfilePictureId");
            AddForeignKey("dbo.Users", "ProfilePictureId", "dbo.ProfilePictures", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ProfilePictureId", "dbo.ProfilePictures");
            DropIndex("dbo.Users", new[] { "ProfilePictureId" });
            DropColumn("dbo.Users", "ProfilePictureId");
            DropTable("dbo.ProfilePictures");
        }
    }
}
