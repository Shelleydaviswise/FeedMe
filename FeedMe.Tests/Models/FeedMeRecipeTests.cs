using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedMe.Models;

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
            Recipe.RecipeId = 1;
            Recipe.Notes = "Love this one.";
            Recipe.Image= "https://google.com";
            Recipe.Yield = "Four Servings";
            Recipe.Summary = "A light meal great for entertaining.";
            Recipe.Ingredients = "eggs, milk, potatoes";
            Recipe.DateSaved = when_saved;
            //Recipe.DietLabels = 
            //Recipe.HealthLabels = 


            Assert.AreEqual(1, Recipe.RecipeId);
            Assert.AreEqual("Love this one.", Recipe.Notes);
            Assert.AreEqual("https://google.com", Recipe.Image);
            Assert.AreEqual("Four Servings", Recipe.Yield);
            Assert.AreEqual("A light meal great for entertaining.", Recipe.Summary);
            Assert.AreEqual("eggs, milk, potatoes", Recipe.Ingredients);
            Assert.AreEqual(when_saved, Recipe.DateSaved);

        }
        


    }
}
