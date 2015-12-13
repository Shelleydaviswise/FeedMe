using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models
{
    public class Recipe
    {
        public static object DateSaved { get; set; }
        [Key]
        public static int RecipeId { get; set; }
        public static string Image { get; set; }
        public static string Ingredients { get; set; }
        public static string Notes { get; set; }
        public static string Summary { get; set; }
        public static string Yield { get; set; }
    }
}