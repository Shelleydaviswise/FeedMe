using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models
{
    public class Recipe : IComparable
    {
        public object DateSaved { get; set; }

        public string Title { get; set; }

        [Key]
        public int RecipeId { get; set; }
        public string Image { get; set; }
        public List<IngredientLines> Ingredients { get; set; }
        public string URL { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0: yyyy-MM-dd)", ApplyFormatInEditMode = true)]
        //public DateTime RecipeSaveDate { get; set; }

        public string Summary { get; set; }
        public int Yield { get; set; }

        [Display(Name ="Diet Labels" )]
        public string DietLabels { get; set; }

        [Display(Name = "Health Labels")]
        public string HealthLabels { get; set; }
        //public string Notes { get; set; }

        public int CompareTo(object obj)
        {
            //Sorting on the Recipe Title

            // We need to explicitly cast from object type to Recipe Type
            Recipe other_recipe = obj as Recipe;
            int response = this.Title.CompareTo(other_recipe.Title);
            return response;
        }
    }
}
