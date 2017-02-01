namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedusermodeltohavenullableobjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Users", "WorkerId", "dbo.Workers");
            DropIndex("dbo.Users", new[] { "ClientId" });
            DropIndex("dbo.Users", new[] { "WorkerId" });
            AlterColumn("dbo.Users", "Rating", c => c.Int());
            AlterColumn("dbo.Users", "ClientId", c => c.Int());
            AlterColumn("dbo.Users", "WorkerId", c => c.Int());
            CreateIndex("dbo.Users", "ClientId");
            CreateIndex("dbo.Users", "WorkerId");
            AddForeignKey("dbo.Users", "ClientId", "dbo.Clients", "Id");
            AddForeignKey("dbo.Users", "WorkerId", "dbo.Workers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Users", "ClientId", "dbo.Clients");
            DropIndex("dbo.Users", new[] { "WorkerId" });
            DropIndex("dbo.Users", new[] { "ClientId" });
            AlterColumn("dbo.Users", "WorkerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Rating", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "WorkerId");
            CreateIndex("dbo.Users", "ClientId");
            AddForeignKey("dbo.Users", "WorkerId", "dbo.Workers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
