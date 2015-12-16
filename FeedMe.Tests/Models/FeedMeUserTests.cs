using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedMe.Models;
using System.Collections.Generic;

namespace FeedMe.Tests.Models
{
    [TestClass]
    public class FeedMeUserTests
    {
        [TestMethod]
        public void FeedMeUserEnsureICanCreateAnInstance()
        {
            FeedMeUser a_user = new FeedMeUser();
            Assert.IsNotNull(a_user);

        }
        [TestMethod]
        public void FeedMeUserEnsureUserHasAllProperties()
        {
            FeedMeUser a_user = new FeedMeUser();

            a_user.FirstName = "Betty";
            a_user.LastName = "Crocker";

            
            Assert.AreEqual("Betty", a_user.FirstName);
            Assert.AreEqual("Crocker", a_user.LastName);
        }

        [TestMethod]
        public void FeedMeUserEnsureUserHasRecipes()
        {
            List<FeedMeRecipe> recipe_list = new List<FeedMeRecipe>
            {
                new FeedMeRecipe { Title = "Chicken Cacciatore" },
                new FeedMeRecipe { Title = "Succulent Beef Stew" }
            };

            FeedMeUser a_user = new FeedMeUser { FirstName = "Betty", Recipes = recipe_list };
            List<FeedMeRecipe> actual_recipes = a_user.Recipes;
            CollectionAssert.AreEqual(recipe_list, actual_recipes);
        }
    }
}
