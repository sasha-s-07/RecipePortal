using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RecipePortal.Models
{
    public class HouseholdIngredient
    {
        [Key]
        public int HouseholdIngredientID { get; set; }

        public string HouseholdIngredientName { get; set; }


        //Utilizes the inverse property to specify the "Many"
        //https://www.entityframeworktutorial.net/code-first/inverseproperty-dataannotations-attribute-in-code-first.aspx
        //One ingredient Many recipes
        public ICollection<Recipe> Recipes { get; set; }

    }
}