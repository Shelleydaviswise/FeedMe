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
            FeedMeRecipe a_recipe = new FeedMeRecipe();
            Assert.IsNotNull(a_recipe);
        }

        [TestMethod]
        public void FeedMeRecipeEnsureRecipeHasAllProperties()
        {
            FeedMeRecipe a_recipe = new FeedMeRecipe();

            DateTime when_saved = DateTime.Now;
            a_recipe.RecipeId = 1;
            a_recipe.Notes = "Love this one.";
            a_recipe.Image= "https://google.com";
            a_recipe.Yield = "Four Servings";
            a_recipe.Summary = "A light meal great for entertaining.";
            a_recipe.DateSaved = when_saved;
            a_recipe.Title = "Chicken Cacciatore";
            a_recipe.DietLabels = "high-protein";
            a_recipe.HealthLabels = "gluten-free";


            Assert.AreEqual(1, a_recipe.RecipeId);
            Assert.AreEqual("Love this one.", a_recipe.Notes);
            Assert.AreEqual("https://google.com", a_recipe.Image);
            Assert.AreEqual("Four Servings", a_recipe.Yield);
            Assert.AreEqual("A light meal great for entertaining.", a_recipe.Summary);
            Assert.AreEqual(when_saved, a_recipe.DateSaved);
            Assert.AreEqual("Chicken Cacciatore", a_recipe.Title);
            Assert.AreEqual("high-protein", a_recipe.DietLabels);
            Assert.AreEqual("gluten-free", a_recipe.HealthLabels);
        }

        [TestMethod]
        public void FeedMeRecipesEnsureRecipeHasIngredients()
        {
            List<Ingredients> ingredients_list = new List<Ingredients>
            {
                new Ingredients { Food = "chicken" },
                new Ingredients {Food = "tomatoes" }
            };

            FeedMeRecipe a_recipe = new FeedMeRecipe { Title = "Chicken Cacciatore", Ingredients = ingredients_list };

            List<Ingredients> actual_ingredients = a_recipe.Ingredients;
            CollectionAssert.AreEqual(ingredients_list, actual_ingredients);

        }
       
    }
}
