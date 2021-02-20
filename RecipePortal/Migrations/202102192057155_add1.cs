namespace RecipePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        CuisineID = c.Int(nullable: false, identity: true),
                        CuisineName = c.String(),
                    })
                .PrimaryKey(t => t.CuisineID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(),
                        RecipeLink = c.String(),
                        CookingTime = c.String(),
                        CuisineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeID)
                .ForeignKey("dbo.Cuisines", t => t.CuisineID, cascadeDelete: true)
                .Index(t => t.CuisineID);
            
            CreateTable(
                "dbo.HouseholdIngredients",
                c => new
                    {
                        HouseholdIngredientID = c.Int(nullable: false, identity: true),
                        HouseholdIngredientName = c.String(),
                    })
                .PrimaryKey(t => t.HouseholdIngredientID);
            
            CreateTable(
                "dbo.HouseholdIngredientRecipes",
                c => new
                    {
                        HouseholdIngredient_HouseholdIngredientID = c.Int(nullable: false),
                        Recipe_RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HouseholdIngredient_HouseholdIngredientID, t.Recipe_RecipeID })
                .ForeignKey("dbo.HouseholdIngredients", t => t.HouseholdIngredient_HouseholdIngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeID, cascadeDelete: true)
                .Index(t => t.HouseholdIngredient_HouseholdIngredientID)
                .Index(t => t.Recipe_RecipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseholdIngredientRecipes", "Recipe_RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.HouseholdIngredientRecipes", "HouseholdIngredient_HouseholdIngredientID", "dbo.HouseholdIngredients");
            DropForeignKey("dbo.Recipes", "CuisineID", "dbo.Cuisines");
            DropIndex("dbo.HouseholdIngredientRecipes", new[] { "Recipe_RecipeID" });
            DropIndex("dbo.HouseholdIngredientRecipes", new[] { "HouseholdIngredient_HouseholdIngredientID" });
            DropIndex("dbo.Recipes", new[] { "CuisineID" });
            DropTable("dbo.HouseholdIngredientRecipes");
            DropTable("dbo.HouseholdIngredients");
            DropTable("dbo.Recipes");
            DropTable("dbo.Cuisines");
        }
    }
}
