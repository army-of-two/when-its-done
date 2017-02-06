namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelsagain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dishes", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.PhotoItems", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.ReceivedPayments", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.WorkerReviews", "Dish_Id", "dbo.Dishes");
            DropForeignKey("dbo.Payments", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Dishes", new[] { "Worker_Id" });
            DropIndex("dbo.PhotoItems", new[] { "Worker_Id" });
            DropIndex("dbo.WorkerReviews", new[] { "Dish_Id" });
            DropIndex("dbo.Payments", new[] { "Client_Id" });
            DropIndex("dbo.ReceivedPayments", new[] { "Worker_Id" });
            RenameColumn(table: "dbo.Dishes", name: "Worker_Id", newName: "WorkerId");
            RenameColumn(table: "dbo.PhotoItems", name: "Worker_Id", newName: "WorkerId");
            RenameColumn(table: "dbo.ReceivedPayments", name: "Worker_Id", newName: "WorkerId");
            RenameColumn(table: "dbo.WorkerReviews", name: "Dish_Id", newName: "DishId");
            RenameColumn(table: "dbo.Payments", name: "Client_Id", newName: "ClientId");
            AlterColumn("dbo.Dishes", "WorkerId", c => c.Int(nullable: false));
            AlterColumn("dbo.PhotoItems", "WorkerId", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkerReviews", "DishId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.ReceivedPayments", "WorkerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Gender", c => c.Int(nullable: false));
            CreateIndex("dbo.Dishes", "WorkerId");
            CreateIndex("dbo.PhotoItems", "WorkerId");
            CreateIndex("dbo.WorkerReviews", "DishId");
            CreateIndex("dbo.Payments", "ClientId");
            CreateIndex("dbo.ReceivedPayments", "WorkerId");
            AddForeignKey("dbo.Dishes", "WorkerId", "dbo.Workers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhotoItems", "WorkerId", "dbo.Workers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReceivedPayments", "WorkerId", "dbo.Workers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkerReviews", "DishId", "dbo.Dishes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.WorkerReviews", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.ReceivedPayments", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.PhotoItems", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Dishes", "WorkerId", "dbo.Workers");
            DropIndex("dbo.ReceivedPayments", new[] { "WorkerId" });
            DropIndex("dbo.Payments", new[] { "ClientId" });
            DropIndex("dbo.WorkerReviews", new[] { "DishId" });
            DropIndex("dbo.PhotoItems", new[] { "WorkerId" });
            DropIndex("dbo.Dishes", new[] { "WorkerId" });
            AlterColumn("dbo.Users", "Gender", c => c.Int());
            AlterColumn("dbo.ReceivedPayments", "WorkerId", c => c.Int());
            AlterColumn("dbo.Payments", "ClientId", c => c.Int());
            AlterColumn("dbo.WorkerReviews", "DishId", c => c.Int());
            AlterColumn("dbo.PhotoItems", "WorkerId", c => c.Int());
            AlterColumn("dbo.Dishes", "WorkerId", c => c.Int());
            RenameColumn(table: "dbo.Payments", name: "ClientId", newName: "Client_Id");
            RenameColumn(table: "dbo.WorkerReviews", name: "DishId", newName: "Dish_Id");
            RenameColumn(table: "dbo.ReceivedPayments", name: "WorkerId", newName: "Worker_Id");
            RenameColumn(table: "dbo.PhotoItems", name: "WorkerId", newName: "Worker_Id");
            RenameColumn(table: "dbo.Dishes", name: "WorkerId", newName: "Worker_Id");
            CreateIndex("dbo.ReceivedPayments", "Worker_Id");
            CreateIndex("dbo.Payments", "Client_Id");
            CreateIndex("dbo.WorkerReviews", "Dish_Id");
            CreateIndex("dbo.PhotoItems", "Worker_Id");
            CreateIndex("dbo.Dishes", "Worker_Id");
            AddForeignKey("dbo.Payments", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.WorkerReviews", "Dish_Id", "dbo.Dishes", "Id");
            AddForeignKey("dbo.ReceivedPayments", "Worker_Id", "dbo.Workers", "Id");
            AddForeignKey("dbo.PhotoItems", "Worker_Id", "dbo.Workers", "Id");
            AddForeignKey("dbo.Dishes", "Worker_Id", "dbo.Workers", "Id");
        }
    }
}
