namespace RecipePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HouseholdIngredientsRecipes", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.HouseholdIngredientsRecipes", "HouseholdIngredientID", "dbo.HouseholdIngredients");
            CreateTable(
                "dbo.HouseholdIngredientsxRecipes",
                c => new
                    {
                        RecipeID = c.Int(nullable: false),
                        HouseholdIngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeID, t.HouseholdIngredientID })
                .ForeignKey("dbo.HouseholdIngredients", t => t.HouseholdIngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true);
            
            DropTable("dbo.HouseholdIngredientsxRecipes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HouseholdIngredientsRecipes",
                c => new
                    {
                        RecipeID = c.Int(nullable: false),
                        HouseholdIngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeID, t.HouseholdIngredientID });
            
            DropForeignKey("dbo.HouseholdIngredientsRecipes", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.HouseholdIngredientsRecipes", "HouseholdIngredientID", "dbo.HouseholdIngredients");
            DropTable("dbo.HouseholdIngredientsRecipes");
            AddForeignKey("dbo.HouseholdIngredientsxRecipes", "HouseholdIngredientID", "dbo.HouseholdIngredients", "HouseholdIngredientID", cascadeDelete: true);
            AddForeignKey("dbo.HouseholdIngredientsxRecipes", "RecipeID", "dbo.Recipes", "RecipeID", cascadeDelete: true);
        }
    }
}
