using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace RecipePortal.Models
{
    public class RecipePortalDataContext : DbContext
    {
        public RecipePortalDataContext() : base("name=RecipePortalDataContext")
        {

        }

        //Instruction to set the models as tables in our database.
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<HouseholdIngredient> Ingredients { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasMany<HouseholdIngredient>(s => s.HouseholdIngredients)
                .WithMany(x => x.Recipes)
                .Map(cs =>
                {
                    cs.MapLeftKey("RecipeID");
                    cs.MapRightKey("HouseholdIngredientID");
                    cs.ToTable("HouseholdIngredientsRecipes");
                });
            
            
        }

    }

}
