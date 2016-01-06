using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedMe.Models;
using System.Collections.Generic;

namespace FeedMe.Tests.Models
{
    [TestClass]
    public class FeedMeRecipeTests
    {
        [TestMethod]
        public void FeedMeRecipeEnsureICanCreateAnInstance()
        {
            Recipe a_recipe = new Recipe();
            Assert.IsNotNull(a_recipe);
        }

        [TestMethod]
        public void FeedMeRecipeEnsureRecipeHasAllProperties()
        {
            Recipe a_recipe = new Recipe();

            DateTime when_saved = DateTime.Now;
            a_recipe.RecipeId = 1;
            a_recipe.Image= "https://google.com";
            a_recipe.Yield = "Four Servings";
            a_recipe.Summary = "A light meal great for entertaining.";
            a_recipe.DateSaved = when_saved;
            a_recipe.Title = "Chicken Cacciatore";
            a_recipe.DietLabels = "high-protein";
            a_recipe.HealthLabels = "gluten-free";
            a_recipe.URL = "http://www.myrecipes.com/recipe/chicken-cacciatore";


            Assert.AreEqual(1, a_recipe.RecipeId);
            Assert.AreEqual("https://google.com", a_recipe.Image);
            Assert.AreEqual("Four Servings", a_recipe.Yield);
            Assert.AreEqual("A light meal great for entertaining.", a_recipe.Summary);
            Assert.AreEqual(when_saved, a_recipe.DateSaved);
            Assert.AreEqual("Chicken Cacciatore", a_recipe.Title);
            Assert.AreEqual("high-protein", a_recipe.DietLabels);
            Assert.AreEqual("gluten-free", a_recipe.HealthLabels);
            Assert.AreEqual("http://www.myrecipes.com/recipe/chicken-cacciatore", a_recipe.URL);

        }

        [TestMethod]
        public void FeedMeRecipesEnsureRecipeHasIngredients()
        {
            List<RecipeIngredients> ingredients_list = new List<RecipeIngredients>
            {
                new RecipeIngredients { Food = "chicken" },
                new RecipeIngredients {Food = "tomatoes" }
            };

            Recipe a_recipe = new Recipe { Title = "Chicken Cacciatore", Ingredients = ingredients_list };

            List<RecipeIngredients> actual_ingredients = a_recipe.Ingredients;
            CollectionAssert.AreEqual(ingredients_list, actual_ingredients);

        }
       
    }
}
