namespace WhenItsDone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelswithvalidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recipes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ingredients", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Foods", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.NutritionFacts", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Minerals", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vitamins", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recipes", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Recipes", "Description", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Foods", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Minerals", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vitamins", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vitamins", "Name", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Minerals", "Name", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Foods", "Name", c => c.String());
            AlterColumn("dbo.Recipes", "Description", c => c.String());
            AlterColumn("dbo.Recipes", "Name", c => c.String());
            DropColumn("dbo.Vitamins", "IsDeleted");
            DropColumn("dbo.Minerals", "IsDeleted");
            DropColumn("dbo.NutritionFacts", "IsDeleted");
            DropColumn("dbo.Foods", "IsDeleted");
            DropColumn("dbo.Ingredients", "IsDeleted");
            DropColumn("dbo.Recipes", "IsDeleted");
            DropColumn("dbo.Dishes", "IsDeleted");
        }
    }
}
