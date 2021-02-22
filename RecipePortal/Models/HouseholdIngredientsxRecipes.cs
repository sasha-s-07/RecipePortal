namespace RecipePortal.Models
{
    public class HouseholdIngredientsxRecipes
    {
        public int HouseholdIngredientsxRecipesID { get; set; }

        public HouseholdIngredientsxRecipes HouseholdIngredientName { get; set; }
        
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
        public int HouseholdIngredientID { get; set; }
        public HouseholdIngredient HouseholdIngredient { get; set; }
    }
}