namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedwithcooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.RecipeId)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.FoodId)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IngredientType = c.Int(nullable: false),
                        MeasurementUnitType = c.Int(nullable: false),
                        PricePerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NutritionFactsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NutritionFacts", t => t.NutritionFactsId, cascadeDelete: true)
                .Index(t => t.NutritionFactsId);
            
            CreateTable(
                "dbo.NutritionFacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Calories = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Carbohydrates = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fats = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Protein = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Minerals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NutritionFacts_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NutritionFacts", t => t.NutritionFacts_Id)
                .Index(t => t.NutritionFacts_Id);
            
            CreateTable(
                "dbo.Vitamins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NutritionFacts_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NutritionFacts", t => t.NutritionFacts_Id)
                .Index(t => t.NutritionFacts_Id);
            
            AddColumn("dbo.PhotoItems", "Dish_Id", c => c.Int());
            AlterColumn("dbo.PhotoItems", "Url", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.VideoItems", "Url", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.WorkerReviews", "ReviewContent", c => c.String(nullable: false, maxLength: 250));
            CreateIndex("dbo.PhotoItems", "Dish_Id");
            AddForeignKey("dbo.PhotoItems", "Dish_Id", "dbo.Dishes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Dishes", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Foods", "NutritionFactsId", "dbo.NutritionFacts");
            DropForeignKey("dbo.Vitamins", "NutritionFacts_Id", "dbo.NutritionFacts");
            DropForeignKey("dbo.Minerals", "NutritionFacts_Id", "dbo.NutritionFacts");
            DropForeignKey("dbo.PhotoItems", "Dish_Id", "dbo.Dishes");
            DropIndex("dbo.Vitamins", new[] { "NutritionFacts_Id" });
            DropIndex("dbo.Minerals", new[] { "NutritionFacts_Id" });
            DropIndex("dbo.Foods", new[] { "NutritionFactsId" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            DropIndex("dbo.Ingredients", new[] { "FoodId" });
            DropIndex("dbo.PhotoItems", new[] { "Dish_Id" });
            DropIndex("dbo.Dishes", new[] { "Worker_Id" });
            DropIndex("dbo.Dishes", new[] { "RecipeId" });
            AlterColumn("dbo.WorkerReviews", "ReviewContent", c => c.String());
            AlterColumn("dbo.VideoItems", "Url", c => c.String());
            AlterColumn("dbo.PhotoItems", "Url", c => c.String());
            DropColumn("dbo.PhotoItems", "Dish_Id");
            DropTable("dbo.Vitamins");
            DropTable("dbo.Minerals");
            DropTable("dbo.NutritionFacts");
            DropTable("dbo.Foods");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Recipes");
            DropTable("dbo.Dishes");
        }
    }
}
