namespace RecipePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.HouseholdIngredientRecipes", newName: "HouseholdIngredientsRecipes");
            RenameColumn(table: "dbo.HouseholdIngredientsRecipes", name: "HouseholdIngredient_HouseholdIngredientID", newName: "HouseholdIngredientID");
            RenameColumn(table: "dbo.HouseholdIngredientsRecipes", name: "Recipe_RecipeID", newName: "RecipeID");
            RenameIndex(table: "dbo.HouseholdIngredientsRecipes", name: "IX_Recipe_RecipeID", newName: "IX_RecipeID");
            RenameIndex(table: "dbo.HouseholdIngredientsRecipes", name: "IX_HouseholdIngredient_HouseholdIngredientID", newName: "IX_HouseholdIngredientID");
            DropPrimaryKey("dbo.HouseholdIngredientsRecipes");
            AddPrimaryKey("dbo.HouseholdIngredientsRecipes", new[] { "RecipeID", "HouseholdIngredientID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.HouseholdIngredientsRecipes");
            AddPrimaryKey("dbo.HouseholdIngredientsRecipes", new[] { "HouseholdIngredient_HouseholdIngredientID", "Recipe_RecipeID" });
            RenameIndex(table: "dbo.HouseholdIngredientsRecipes", name: "IX_HouseholdIngredientID", newName: "IX_HouseholdIngredient_HouseholdIngredientID");
            RenameIndex(table: "dbo.HouseholdIngredientsRecipes", name: "IX_RecipeID", newName: "IX_Recipe_RecipeID");
            RenameColumn(table: "dbo.HouseholdIngredientsRecipes", name: "RecipeID", newName: "Recipe_RecipeID");
            RenameColumn(table: "dbo.HouseholdIngredientsRecipes", name: "HouseholdIngredientID", newName: "HouseholdIngredient_HouseholdIngredientID");
            RenameTable(name: "dbo.HouseholdIngredientsRecipes", newName: "HouseholdIngredientRecipes");
        }
    }
}
