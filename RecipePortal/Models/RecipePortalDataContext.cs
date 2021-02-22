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

        public DbSet<HouseholdIngredientsxRecipes> HouseholdIngredients { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
       
            modelBuilder.Entity<HouseholdIngredientsxRecipes>()
                .HasKey(cs => new { cs.RecipeID, cs.HouseholdIngredientID });
        }
    }


    }

    


