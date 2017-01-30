namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDishmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "Rating");
        }
    }
}
