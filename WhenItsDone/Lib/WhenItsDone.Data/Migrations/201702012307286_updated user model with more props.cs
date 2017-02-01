namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedusermodelwithmoreprops : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Workers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.Workers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Clients", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.Clients", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "HeightInCm", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "WeightInKg", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workers", "WeightInKg", c => c.Int());
            AlterColumn("dbo.Workers", "HeightInCm", c => c.Int());
            DropColumn("dbo.Clients", "Age");
            DropColumn("dbo.Clients", "Gender");
            DropColumn("dbo.Clients", "LastName");
            DropColumn("dbo.Clients", "FirstName");
            DropColumn("dbo.Clients", "Rating");
            DropColumn("dbo.Workers", "Age");
            DropColumn("dbo.Workers", "Gender");
            DropColumn("dbo.Workers", "LastName");
            DropColumn("dbo.Workers", "FirstName");
            DropColumn("dbo.Workers", "Rating");
        }
    }
}
