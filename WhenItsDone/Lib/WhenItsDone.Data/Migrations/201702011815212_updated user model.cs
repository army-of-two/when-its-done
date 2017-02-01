namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedusermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Rating");
        }
    }
}
