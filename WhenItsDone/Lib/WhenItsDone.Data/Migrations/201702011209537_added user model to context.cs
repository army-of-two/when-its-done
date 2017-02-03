namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedusermodeltocontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        ClientId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.WorkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Users", "ClientId", "dbo.Clients");
            DropIndex("dbo.Users", new[] { "WorkerId" });
            DropIndex("dbo.Users", new[] { "ClientId" });
            DropTable("dbo.Users");
        }
    }
}
