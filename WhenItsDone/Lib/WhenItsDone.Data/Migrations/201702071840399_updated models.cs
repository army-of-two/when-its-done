namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "NutritionFactsId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "AspNetUserId", c => c.Guid(nullable: false));
            AddColumn("dbo.VideoItems", "Dish_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "NutritionFactsId");
            CreateIndex("dbo.VideoItems", "Dish_Id");
            AddForeignKey("dbo.Recipes", "NutritionFactsId", "dbo.NutritionFacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VideoItems", "Dish_Id", "dbo.Dishes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoItems", "Dish_Id", "dbo.Dishes");
            DropForeignKey("dbo.Recipes", "NutritionFactsId", "dbo.NutritionFacts");
            DropIndex("dbo.VideoItems", new[] { "Dish_Id" });
            DropIndex("dbo.Recipes", new[] { "NutritionFactsId" });
            DropColumn("dbo.VideoItems", "Dish_Id");
            DropColumn("dbo.Users", "AspNetUserId");
            DropColumn("dbo.Recipes", "NutritionFactsId");
        }
    }
}
