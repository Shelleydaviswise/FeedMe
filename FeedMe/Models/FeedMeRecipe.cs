using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models
{
    public class FeedMeRecipe : IComparable
    {
        public object DateSaved { get; set; }
    
        public string Title { get; set; }

        [Key]
        public int RecipeId { get; set; }
        public string Image { get; set; }
        public List<Ingredients> Ingredients { get; set; }
        public string Notes { get; set; }
        public string Summary { get; set; }
        public string Yield { get; set; }
        public string DietLabels { get; set; }
        public string HealthLabels { get; set; }



        public int CompareTo(object obj)
        {
         //Sorting on the Recipe Title

            // We need to explicitly cast from object type to Recipe Type
            FeedMeRecipe other_recipe= obj as FeedMeRecipe;
            int response = this.Title.CompareTo(other_recipe.Title);
            return response;
        }
    }
}