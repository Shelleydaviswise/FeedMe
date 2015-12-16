using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FeedMe.Models
{
    public class FeedMeRepository
    {
        private FeedMeContext _context;
        public FeedMeContext Context { get { return _context; } }

        public FeedMeRepository()
        {
            _context = new FeedMeContext();
        }

        public FeedMeRepository(FeedMeContext a_context)
        {
            _context = a_context;
        }

        public List<FeedMeRecipe> GetAllRecipes()
        {
            var query = from recipes in _context.Recipes select recipes;
            return query.ToList();
        }


        public List<FeedMeRecipe> SearchByDietLabels(string label)
        {
            // SQL: select * from Recipes As recipes where recipes.DietLabels like '%dietlabels%';
            // handleblah
            // blahhandle
            // blahhandleblah
            var query = from recipes in _context.Recipes select recipes;
            List<FeedMeRecipe> found_labels = query.Where(recipe => recipe.DietLabels.Contains(label)).ToList();
            found_labels.Sort();
            return found_labels;
        }

        public List<FeedMeRecipe> SearchByHealthLabels(string label)
        {
            // SQL: select * from Recipes As recipes where recipes.DietLabels like '%dietlabels%';
            // handleblah
            // blahhandle
            // blahhandleblah
            var query = from recipes in _context.Recipes select recipes;
            List<FeedMeRecipe> found_labels = query.Where(recipe => recipe.HealthLabels.Contains(label)).ToList();
            found_labels.Sort();
            return found_labels;
        }

        //public List<FeedMeRecipe> SearchByDietLabels(string search_term)

        //{
        //SQL: select * from JitterUsers AS users where users.FirstName like '%search_term%' OR users.LastName like '%search_term%';
        // var query = from recipes in _context.Recipes select recipes;
        // List<FeedMeRecipe> found_recipes = query.Where(recipe => Regex.IsMatch(recipe.DietLabels, search_term, RegexOptions.IgnoreCase)).ToList();
        // found_recipes.Sort();
        //return found_recipes;
        //  }

        // public List<FeedMeRecipe> SearchByHealthLabels(string search_term)

        // {
        //SQL: select * from JitterUsers AS users where users.FirstName like '%search_term%' OR users.LastName like '%search_term%';
        //  var query = from recipes in _context.Recipes select recipes;
        //  List<FeedMeRecipe> found_recipes = query.Where(recipe => Regex.IsMatch(recipe.HealthLabels, search_term, RegexOptions.IgnoreCase)).ToList();
        // found_recipes.Sort();
        // return found_recipes;
        // }


    }
}