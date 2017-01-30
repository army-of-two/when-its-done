namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedallowedurllength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhotoItems", "Url", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.VideoItems", "Url", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VideoItems", "Url", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.PhotoItems", "Url", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
