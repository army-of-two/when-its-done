namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedratingtoVideoItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoItems", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VideoItems", "Rating");
        }
    }
}
