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

        // Get All the Recipes
        public List<Recipe> GetAllRecipes()
        {
            var query = from recipes in _context.Recipes select recipes;
            return query.ToList();
        }


        //Get All the Recipes for a certain User
        public List<Recipe> GetUserRecipes(FeedMeUser user)
        {
            if (user != null)
            {
                var query = from u in _context.FeedMeUsers where u.FeedMeUserId == user.FeedMeUserId select u;
                FeedMeUser found_user = query.SingleOrDefault<FeedMeUser>();
                if (found_user == null)
                {
                    return new List<Recipe>();
                }
                return found_user.Recipes;
            } else
            {
                return new List<Recipe>();
            }

        }

        //





    // Search Recipes by various parameters
        public List<Recipe> SearchByTitle(string search_term)
        {
            // SQL: select * from Recipes As recipes where recipes.DietLabels like '%dietlabels%';
            
            var query = from recipes in _context.Recipes select recipes;
            List<Recipe> found_titles = query.Where(recipe => recipe.Title.Contains(search_term)).ToList();
            found_titles.Sort();
            return found_titles;
        }



        public List<Recipe> SearchByDietLabels(string label)
        {
            // SQL: select * from Recipes As recipes where recipes.DietLabels like '%dietlabels%';
            // handleblah
            // blahhandle
            // blahhandleblah
            var query = from recipes in _context.Recipes select recipes;
            List<Recipe> found_labels = query.Where(recipe => recipe.DietLabels.Contains(label)).ToList();
            found_labels.Sort();
            return found_labels;
        }

        public List<Recipe> SearchByHealthLabels(string label)
        {
            // SQL: select * from Recipes As recipes where recipes.DietLabels like '%dietlabels%';
            // handleblah
            // blahhandle
            // blahhandleblah
            var query = from recipes in _context.Recipes select recipes;
            List<Recipe> found_labels = query.Where(recipe => recipe.HealthLabels.Contains(label)).ToList();
            found_labels.Sort();
            return found_labels;
        }
    }
}
